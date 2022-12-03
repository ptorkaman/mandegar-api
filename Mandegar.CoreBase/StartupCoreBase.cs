using Mandegar.CoreBase.Culture;
using Mandegar.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Middlewares;
using Newtonsoft.Json.Serialization;
using NLog;
using System;
using System.Text;

namespace Mandegar.CoreBase
{
    public class StartupCoreBase
    {
        public IConfiguration Configuration { get; }
        public string EndpointName { private set; get; }

        public StartupCoreBase(IConfiguration configuration, string endpointName = "base")
        {
            Configuration = configuration;
            EndpointName = endpointName;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            #region Cors
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins(Configuration["UiSettings:url"]);
            }));
            #endregion

            #region CookiePolicy

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;

                //فقط هنگام تست
                options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
            });

            #endregion

            #region JWT
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWTCoreSettings:SecretKey"]));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            #region Install Projects Services

            StartupConfiguration.Installer.Install(services, Configuration);

            #endregion

            #region Api Versioning
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });

            #endregion

            #region Swagger
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation  
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Auth"
                });
                // To Enable authorization using Swagger (JWT)  
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            #endregion

            //NLog
            //services.AddScoped<LogFilter>();

            #region AllowSynchronousIO
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            #endregion


            services.AddLocalizaionServices();

            services.AddControllersWithViews()
                 .AddSessionStateTempDataProvider()
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });

            services.AddResponseCompression();
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Set EndPointName For NLog
            GlobalDiagnosticsContext.Set("EndpointName", EndpointName);

            //TODO: این رو موقع پابلیش نهایی روی سرور از کامنت در بیاریم، اپستینگز رو درست کنیم
            //app.UseTrustedUrls();

            //app.UseAntiXssMiddleware();
            app.UseExceptionLogger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }
            else
            {
                app.UseHttpsRedirection();
            }
            app.UseResponseCompression();
            app.UseCors("CorsPolicy");
            app.UseSecurityHeaders();
            app.UseCookiePolicy();
            app.UseFileServer();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseRequestResponseLogging();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }

    }
}
