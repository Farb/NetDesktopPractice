using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfAppNetTest.Converter
{
    class Length2BoolConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value.ToString();
            return str.Length > 6;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
