using Microsoft.Extensions.Localization;
using System.Text;

namespace Mandegar.CoreBase.Culture
{
    public class LocalizedResultMessageResolver : IResultMessageResolver
    {
        public LocalizedResultMessageResolver()
        {
        }

        public string BuildMessage(IStringLocalizer localizer, int code, params object[] parameters)
        {
            string format = localizer.GetString(code.ToString());
            if (string.IsNullOrWhiteSpace(format))
            {
                return code.ToString();
            }

            return string.Format(format, parameters);
        }
    }
}
