using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    internal class MultiDouble2Visibility : IMultiValueConverter
    {
        /// <summary>
        /// 根据可视范围,判定雷达点位是否应该显示在雷达上
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            /// <param name="values[0]">雷达的点位(Thickness)(无用)</param>
            /// <param name="values[1]">雷达搜索半径</param>
            /// <param name="values[2]">当前点位离中心点的距离</param>
            /// <param name="values[3]">当前点位是否为离线状态</param>
            /// <param name="values[4]">当前离线点位是否要显示</param>
            if (values == null)
            {
                return Visibility.Collapsed;
            }

            if (values.Length != 5)
            {
                return Visibility.Collapsed;
            }

            bool isOnline = (bool)values[3];
            bool isShowOffline = (bool)values[4];
            // 离线点位是否显示根据筛选面板中的离线按钮来控制
            if (!isOnline && isShowOffline)
            {
                return Visibility.Collapsed;
            }

            //Thickness pt = (Thickness)values[0];  // USELESS
            double radius = (double)values[1];
            int distance = (int)values[2];

            // 说明:
            // 圆的方程是x²+y²=r², 圆心坐标(0,0), 如果x1²+y1²≤r², 就说明点位在圆内
            //if (Math.Pow(pt.Left/2.0, 2) + Math.Pow(pt.Top/2.0, 2) <= Math.Pow(120, 2))
            //{
            //    return Visibility.Visible;
            //}

            return distance <= radius ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
