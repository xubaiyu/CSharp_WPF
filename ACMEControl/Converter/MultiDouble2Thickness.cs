using ACMEControl.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ACMEControl.Converter
{
    internal class MultiDouble2Thickness : IMultiValueConverter
    {
        /// <summary>
        /// 点位在雷达的上的位置转换
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
            {
                return 0;
            }

            if (values.Length != 10)
            {
                return 0;
            }

            /// <param name="values[0]">第一点纬度(中心点位)(无用)</param>
            /// <param name="values[1]">第一点经度(中心点位)(无用)</param>
            /// <param name="values[2]">第二点纬度(目标点位)(无用)</param>
            /// <param name="values[3]">第二点经度(目标点位)(无用)</param>
            /// <param name="values[4]">中心点位的视野角度(无用)</param>
            /// <param name="values[5]">中心点位的可视范围</param>
            /// <param name="values[6]">雷达窗口的宽度</param>
            /// <param name="values[7]">雷达窗口的高度</param>
            /// <param name="values[8]">当前点位与中心点位的相对角度</param>
            /// <param name="values[9]">当前点位离中心点位的距离</param>

            // 说明: 现在直接从服务器获取每个点位与中心点位夹角和距离, 
            //       不用再通过点位的经纬度计算夹角和距离值.
            //double angle = SphereCalc.GetAngle((double)values[0], (double)values[1], (double)values[2], (double)values[3], (double)values[4]);
            //double distance = SphereCalc.GetDistance((double)values[0], (double)values[1], (double)values[2], (double)values[3]);

            double angle = SphereCalc.Rad((double)values[8]);
            int distance = (int)values[9];

            double tempWidth = (double)values[6] / 2.0;
            double left = tempWidth * (distance * Math.Cos(angle - Math.PI / 2.0)) / ((double)values[5]);
            double tempHeight = (double)values[7] / 2.0;
            double top = tempHeight * (distance * Math.Sin(angle - Math.PI / 2.0)) / ((double)values[5]);

            return new Thickness(left * 2, top * 2, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
