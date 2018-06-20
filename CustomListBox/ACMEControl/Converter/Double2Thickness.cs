using ACMEControl.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    internal class Double2Thickness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = (double)value;
            string param = (string)parameter;
            switch (param)
            {
                case "LeftUp":
                    return new Thickness(v, v, 0, 0);
                case "RightUp":
                    return new Thickness(0, v, v, 0);
                case "LeftDown":
                    return new Thickness(v, 0, 0, v);
                case "RightDown":
                    return new Thickness(0, 0, v, v);
            }
            return new Thickness(0, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
