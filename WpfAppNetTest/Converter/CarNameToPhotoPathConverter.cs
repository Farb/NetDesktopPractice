using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfAppNetTest.Converter
{
    class CarNameToPhotoPathConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string url = $"/Images/Cars/{value}.jpg";
            return new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
