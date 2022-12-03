using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;

namespace Mandegar.Utilities.ActionFilters
{
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayNameAttribute(string resourceId, Type resourceType)
            : base(GetResxValueByName(resourceId, resourceType))
        { }

        private static string GetResxValueByName(string key, Type resourceType)
        {
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceType);
            var entry =
                rm.GetResourceSet(System.Threading.Thread.CurrentThread.CurrentCulture, true, true)
                  .OfType<DictionaryEntry>()
                  .FirstOrDefault(e => e.Value.ToString() == key);

            var value = entry.Value?.ToString();
            return value;

        }
    }
}
