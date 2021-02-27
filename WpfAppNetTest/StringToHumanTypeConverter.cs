using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace WpfAppNetTest
{
    public class StringToHumanTypeConverter:TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var human = new Human
                {
                    Name = value.ToString()
                };
                return human;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
