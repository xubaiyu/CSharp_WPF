using ACMEControl.RountedEventHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACMEControl.Controls
{
    /// <summary>
    /// 雷达点位列表集合
    /// </summary>
    public partial class RadarListBox : ItemsControl
    {
        static RadarListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadarListBox), new FrameworkPropertyMetadata(typeof(RadarListBox)));
        }


        /// <summary>
        /// 雷达点位的点击事件
        /// </summary>
        public event RadarListClickRoutedEventHandle RadarItemClick
        {
            add { this.AddHandler(RadarItemClickEvent, value); }
            remove { this.RemoveHandler(RadarItemClickEvent, value); }
        }

        public static readonly RoutedEvent RadarItemClickEvent = EventManager.RegisterRoutedEvent(
                                "RadarItemClick", RoutingStrategy.Bubble, typeof(RadarListClickRoutedEventHandle), typeof(RadarListBox));

        /// <summary>
        /// 雷达点位的移进事件
        /// </summary>
        public event RadarListClickRoutedEventHandle RadarItemMouseEnter
        {
            add { this.AddHandler(RadarItemMouseEnterEvent, value); }
            remove { this.RemoveHandler(RadarItemMouseEnterEvent, value); }
        }

        public static readonly RoutedEvent RadarItemMouseEnterEvent = EventManager.RegisterRoutedEvent(
                                "RadarItemMouseEnter", RoutingStrategy.Bubble, typeof(RadarListClickRoutedEventHandle), typeof(RadarListBox));

        /// <summary>
        /// 雷达中心点 经度
        /// </summary>
        public double Lng
        {
            get { return (double)GetValue(LngProperty); }
            set { SetValue(LngProperty, value); }
        }

        public static readonly DependencyProperty LngProperty =
            DependencyProperty.Register("Lng", typeof(double), typeof(RadarListBox), new PropertyMetadata(0.0));

        /// <summary>
        /// 雷达中心点 纬度
        /// </summary>
        public double Lat
        {
            get { return (double)GetValue(LatProperty); }
            set { SetValue(LatProperty, value); }
        }

        public static readonly DependencyProperty LatProperty =
            DependencyProperty.Register("Lat", typeof(double), typeof(RadarListBox), new PropertyMetadata(0.0));


        /// <summary>
        /// 雷达中心点 视野角度(方位角)
        /// </summary>
        public double Azimuth
        {
            get { return (double)GetValue(AzimuthProperty); }
            set { SetValue(AzimuthProperty, value); }
        }

        public static readonly DependencyProperty AzimuthProperty =
            DependencyProperty.Register("Azimuth", typeof(double), typeof(RadarListBox), new PropertyMetadata(0.0));


        /// <summary>
        /// 雷达中心点的可视范围(默认: 1公里范围内)
        /// </summary>
        public double QueryDistance
        {
            get { return (double)GetValue(QueryDistanceProperty); }
            set { SetValue(QueryDistanceProperty, value); }
        }

        public static readonly DependencyProperty QueryDistanceProperty =
            DependencyProperty.Register("QueryDistance", typeof(double), typeof(RadarListBox), new PropertyMetadata(1000.0));


        /// <summary>
        /// 雷达中心点 摄像头ID
        /// </summary>
        public string CameraID
        {
            get { return (string)GetValue(CameraIDProperty); }
            set { SetValue(CameraIDProperty, value); }
        }

        public static readonly DependencyProperty CameraIDProperty =
            DependencyProperty.Register("CameraID", typeof(string), typeof(RadarListBox), new PropertyMetadata(null));


        /// <summary>
        /// 雷达搜索状态
        /// 正在搜索时, 显示搜索动画
        /// 搜索完成时, 隐藏搜索动画
        /// </summary>
        public bool IsSearch
        {
            get { return (bool)GetValue(IsSearchProperty); }
            set { SetValue(IsSearchProperty, value); }
        }

        public static readonly DependencyProperty IsSearchProperty =
            DependencyProperty.Register("IsSearch", typeof(bool), typeof(RadarListBox), new PropertyMetadata(true));


        /// <summary>
        /// 离线点位是否显示根据筛选面板中的离线按钮来控制
        /// </summary>
        public bool IsShowOffline
        {
            get { return (bool)GetValue(IsShowOfflineProperty); }
            set { SetValue(IsShowOfflineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowOffline.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowOfflineProperty =
            DependencyProperty.Register("IsShowOffline", typeof(bool), typeof(RadarListBox), new PropertyMetadata(false));


    }
}
