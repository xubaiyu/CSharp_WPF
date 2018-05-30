using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    /// <summary>
    /// 最大化按钮根据Resize的使能状态确定是否显示
    /// </summary>
    internal class ResizeMode2Visibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ResizeMode? resizeMode = (ResizeMode?)value;

            if (resizeMode == null)
            {
                return Visibility.Collapsed;
            }

            return resizeMode == ResizeMode.NoResize ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
