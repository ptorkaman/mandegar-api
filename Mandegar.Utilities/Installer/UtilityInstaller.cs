using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.ExcelHelper;
using Mandegar.Utilities.HttpRequest;
using Mandegar.Utilities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mandegar.Utilities
{
    public static class UtilityInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IViewRenderService, RenderViewToString>();
            services.AddScoped<IFileManager, FileManager>();
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpHelper, HttpHelper>();
            services.AddSingleton<ICookieManager, CookieManager>();
            services.AddSingleton<ISendMail, SendMail>();
            services.AddScoped<Map, Map>();
        }

        public static IServiceProvider ConfigureServices(IServiceCollection service)
        {
            var serviceProvider = service.BuildServiceProvider();

            var accessor = serviceProvider.GetService<IHttpContextAccessor>();
            ClaimHelper.SetHttpContextAccessor(accessor);

            return serviceProvider;
        }
    }
}
