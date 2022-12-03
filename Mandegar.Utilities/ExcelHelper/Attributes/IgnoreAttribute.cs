using System;

namespace Mandegar.Utilities.ExcelHelper.Attributes
{
    /// <summary>
    /// Attribute that specifies that a property should be ignored.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class IgnoreAttribute : Attribute
    {
    }
}
