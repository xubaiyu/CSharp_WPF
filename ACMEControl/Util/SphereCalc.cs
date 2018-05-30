using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;

namespace ACMEControl.Util
{
    /// <summary>
    /// 球面相关计算类
    /// </summary>
    public class SphereCalc
    {
        /// <summary>
        /// 地球半径. (单位: 米)
        /// </summary>
        private const double EARTH_RADIUS = 6378137;

        /// <summary>
        /// 根据球面弧度,计算两点位置的距离，返回两点的距离. (单位: 米)
        /// 根据经纬度,计算点位间的距离(中心点位到目标点位) 
        /// </summary>
        /// <param name="lat1">第一点纬度(中心点)</param>
        /// <param name="lng1">第一点经度(中心点)</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns>返回两点的距离</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            // 获取两点间的向量
            Vector3D vec = CalcVector(lat1, lng1, lat2, lng2);

            // 返回向量模
            return vec.Length;
        }

        /// <summary>
        /// 返回目标点位的象限角度
        /// </summary>
        /// </summary>
        /// <param name="lat1">第一点纬度(中心点)</param>
        /// <param name="lng1">第一点经度(中心点)</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <param name="azimuth">中心点位的视野角度</param>
        /// <returns>返回目标点位的象限角度</returns>
        public static double GetAngle(double lat1, double lng1, double lat2, double lng2, double azimuth)
        {
            // 获取两点间的向量
            Vector3D vec = CalcVector(lat1, lng1, lat2, lng2);

            // 点位的正北朝向角的一个方向向量
            Vector3D northAngle = new Vector3D(Math.Tan(Rad(azimuth)), 0, 1);

            // 根据两个向量,计算夹角
            double angle = Vector3D.AngleBetween(vec, northAngle);

            // 如果有一个向量是0向量, 就返回0度
            if (double.IsNaN(angle))
                angle = 0;

            // 参照X和Y平面, 计算投影向量
            Vector vec_XY = new Vector(vec.X, vec.Y);
            Vector northAngle_XY = new Vector(northAngle.X, northAngle.Y);

            // 根据向量叉乘,判断是顺时针,还是逆时针
            if (Vector.CrossProduct(northAngle_XY, vec_XY) < 0)
                angle = 360 - angle;

            // 返回夹角弧度
            return Rad(angle);
        }

        /// <summary>
        /// 经纬度转化成弧度
        /// </summary>
        /// <param name="d">经纬度</param>
        /// <returns></returns>
        public static double Rad(double d)
        {
            return (double)d * Math.PI / 180d;
        }

        /// <summary>
        /// 空间两点的向量计算
        /// </summary>
        /// <param name="lat1">第一点纬度(中心点)</param>
        /// <param name="lng1">第一点经度(中心点)</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns></returns>
        private static Vector3D CalcVector(double lat1, double lng1, double lat2, double lng2)
        {
            // 两点的经纬度转换成弧度
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);

            // 球面参数方程
            double x1 = EARTH_RADIUS * Math.Sin(radLat1) * Math.Cos(radLng1);
            double y1 = EARTH_RADIUS * Math.Sin(radLat1) * Math.Sin(radLng1);
            double z1 = EARTH_RADIUS * Math.Cos(radLat1);

            double x2 = EARTH_RADIUS * Math.Sin(radLat2) * Math.Cos(radLng2);
            double y2 = EARTH_RADIUS * Math.Sin(radLat2) * Math.Sin(radLng2);
            double z2 = EARTH_RADIUS * Math.Cos(radLat2);

            // 两点的空间坐标与球心坐标组成的向量
            Vector3D v1 = new Vector3D(x1, y1, z1);
            Vector3D v2 = new Vector3D(x2, y2, z2);

            Vector3D vec = v2 - v1;

            return vec;
        }

        /// <summary>
        /// 计算两点位置的距离，返回两点的距离，单位 米
        /// 该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <returns>返回两点的距离</returns>
        public static double GetDistanceForGoogle(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = Rad(lat1);
            double radLng1 = Rad(lng1);
            double radLat2 = Rad(lat2);
            double radLng2 = Rad(lng2);

            double a = radLat1 - radLat2;
            double b = radLng1 - radLng2;

            double result = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2)
                            + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) * EARTH_RADIUS;
            return result;
        }
    }
}
