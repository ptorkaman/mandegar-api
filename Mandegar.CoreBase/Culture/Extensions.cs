using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Mandegar.CoreBase.Culture
{
    public static class Extensions
    {

        public static void AddLocalizaionServices(this IServiceCollection services, string resourcesPath = "Resources")
        {
            services.AddJsonLocalization();
            services.AddSingleton<IResultMessageResolver, LocalizedResultMessageResolver>();
        }

        public static void ConfigureContextLangProcessing(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[] { "en-US", "fa-IR" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
        }

        public static IServiceCollection AddJsonLocalization(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IStringLocalizer<>), typeof(JsonStringLocalizer<>));
            return services;
        }
    }
}
