using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    internal class MultiThickness2Thickness : IMultiValueConverter
    {
        /// <summary>
        /// 缩略图的位置转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            /// <param name="values[0]">当前点位按钮的像素位置</param>
            /// <param name="values[1]">雷达窗口尺寸 宽</param>
            /// <param name="values[2]">雷达窗口尺寸 高</param>
            /// <param name="values[3]">缩略图窗口的实际高度</param>
            if (values == null)
            {
                return new Thickness(0, 0, 0, 0);
            }

            if (values.Length != 4)
            {
                return new Thickness(0, 0, 0, 0);
            }

            // 当前点位按钮的像素位置
            Thickness pt = (Thickness)values[0];

            // 雷达窗口尺寸
            double radarWidth = (double)values[1];
            double radarHeight = (double)values[2];

            // 缩略图窗口尺寸
            double popupWndWidth = 90;

            // 缩略图窗口的实际高度, 根据个数而变. 最大150.
            double popupWndHeight = (double)values[3];

            // 缩略图位置与点位按钮的偏移量
            double offset_Width = 90;
            double offset_Height = 55;

            // 设置缩略图窗口的left
            if (pt.Left + offset_Width + popupWndWidth >= radarWidth)
            {
                pt.Left = radarWidth - popupWndWidth;//靠着窗口最右边
            }
            else
            {
                pt.Left = pt.Left + offset_Width;
            }

            // 设置缩略图的top
            if (pt.Top - offset_Height - popupWndHeight <= -radarHeight)
            {
                pt.Top = pt.Top + popupWndHeight;//靠着窗口顶部
            }
            else if (pt.Top + popupWndHeight >= radarHeight)
            {
                pt.Top = pt.Top - popupWndHeight;//靠着窗口底部
            }
            else
            {
                pt.Top = pt.Top - offset_Height;
            }

            return new Thickness(pt.Left, pt.Top, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
