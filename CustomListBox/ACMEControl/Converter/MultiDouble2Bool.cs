using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    /// <summary>
    /// 滚动条两侧显示问题
    /// </summary>
    internal class MultiDouble2Bool : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                return 0;
            if (values.Length != 3)
                return 0;
            return (double)values[0] == (double)values[1] - (double)values[2];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
