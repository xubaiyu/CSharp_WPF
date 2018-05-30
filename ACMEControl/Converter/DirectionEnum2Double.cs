using ACMEControl.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    internal class DirectionEnum2Double : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DirectionEnum dir = (DirectionEnum)value;
            switch (dir)
            {
                case DirectionEnum.Left:
                    return 0;
                case DirectionEnum.Right:
                    return 180;
                case DirectionEnum.Up:
                    return 90;
                case DirectionEnum.Down:
                    return 270;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
