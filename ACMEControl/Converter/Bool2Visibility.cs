using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    public class Bool2Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string para = (string)parameter;
            bool v = (bool)value;
            if (para == "+")
            {
                return v ? Visibility.Visible : Visibility.Collapsed;
            }
            else if (para == "-")
            {
                return v ? Visibility.Collapsed : Visibility.Visible;
            }
            return v ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
