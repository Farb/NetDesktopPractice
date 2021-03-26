using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using WpfAppNetTest.Model;

namespace WpfAppNetTest.Converter
{
    class StateToNullableBoolConverter : IValueConverter
    {
        //State 转为 bool?
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            State state = (State)value;
            return state switch
            {
                State.Available => true,
                State.Locked => false,
                _ => null,
            };
        }

        //bool?转为State
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? nb = (bool?)value;
            return nb switch
            {
                true => State.Available,
                false => State.Locked,
                _ => State.Unknown
            };
        }
    }
}
