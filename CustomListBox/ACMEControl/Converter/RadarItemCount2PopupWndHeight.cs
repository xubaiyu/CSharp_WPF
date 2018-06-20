using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    class RadarItemCount2PopupWndHeight : IValueConverter
    {
        /// <summary>
        /// 根据点位个数转换缩略图窗口的高度
        /// 窗口的最大高度为150.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 取出一杆多机列表的点位个数
            int nCount = (int)value;
            // 每个缩略图窗口的高度
            double height = 55;

            if (nCount >= 3)
            {
                return 150;
            }
            else
            {
                return height * nCount;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
