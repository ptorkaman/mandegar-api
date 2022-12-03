
using Microsoft.Extensions.Configuration;

namespace Mandegar.Utilities.BusinessHelpers
{
    public static class AppsettingsGetter
    {
        public static string Get(string section)
        {

            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables();

            IConfiguration _configuration = builder.Build();

            var value = _configuration.GetSection(section).Value;
            return value;

        }

    }
}
