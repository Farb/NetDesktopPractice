using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Converter
{
    class CategoryToSourceConverter : IValueConverter
    {

        //将Category转换为URI

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Category c = (Category)value;
            switch (c)
            {
                case Category.Bomber:
                    return Path.Combine(Directory.GetCurrentDirectory(), @"Images\Bomber.png");
                case Category.Fighter:
                    return Path.Combine(Directory.GetCurrentDirectory(), @"Images\Fighter.jpg");
                default:
                    return null;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
