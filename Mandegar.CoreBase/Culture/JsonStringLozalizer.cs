using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mandegar.CoreBase.Culture
{
    public class JsonStringLocalizer<T> : IStringLocalizer<T>
    {
        private static string localizationRoot = "Resources";
        private readonly IHttpContextAccessor httpContextAccessor;

        public JsonStringLocalizer(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            string path = config["localization:root"]?.ToString();

            if (!string.IsNullOrWhiteSpace(path))
            {
                if (System.IO.Directory.Exists(path))
                {
                    localizationRoot = path;
                }
            }
        }

        private Lazy<Dictionary<string, IConfiguration>> strings = new Lazy<Dictionary<string, IConfiguration>>(() =>
        {
            string type = typeof(T).Name;
            var builder = new ConfigurationBuilder();
            Dictionary<string, IConfiguration> configurations = new Dictionary<string, IConfiguration>();

            foreach (string path in System.IO.Directory.GetFiles(localizationRoot, type + ".*.json"))
            {
                string key = System.IO.Path.GetFileName(path).Replace(type, "")?.Replace(".json", "")?.Replace(".", "");
                if (string.IsNullOrWhiteSpace(key)) continue;

                configurations.Add(key, builder.AddJsonFile(path, false, true).Build());
            }

            return configurations;

        }, true);


        public LocalizedString this[string name]
        {
            get
            {
                var rqf = httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
                var culture = rqf.RequestCulture.Culture.ToString();
                var config = strings.Value?.FirstOrDefault(x => x.Key == culture).Value;

                if (config != null)
                {
                    string value = config[name]?.ToString();
                    return value == null ? null : new LocalizedString(name, value);
                }

                return null;
            }
        }

        public LocalizedString this[string name, params object[] arguments] => new LocalizedString(name, string.Format(this[name], arguments));

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var rqf = httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture.ToString();

            var config = strings.Value?.FirstOrDefault(x => x.Key == culture).Value;
            return config?.AsEnumerable()?.Select(x => new LocalizedString(x.Key, x.Value));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
