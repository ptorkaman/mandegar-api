using Microsoft.Extensions.Localization;

namespace Mandegar.CoreBase.Culture
{
    public interface IResultMessageResolver
    {
        string BuildMessage(IStringLocalizer localizer, int code, params object[] parameters);
    }
}
