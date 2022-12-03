using System;
using System.ComponentModel;
using System.Globalization;

namespace Mandegar.Utilities.CustomAttributes
{
    public class CustomNumberTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string s)
            {
                return Decimal.Parse(s, NumberStyles.AllowThousands, culture);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
                return ((Decimal)value).ToString("N0", culture);

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
