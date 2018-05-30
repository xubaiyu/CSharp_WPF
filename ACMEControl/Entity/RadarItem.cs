using ACMEControl.Args;
using ACMEControl.Controls;
using ACMEControl.ResourcePath;
using ACMEControl.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ACMEControl.Entity
{
    public class RadarItem : ObservableObject
    {
        public RelayCommand<RadarListBox> ItemClickCommand { get; set; }

        public RelayCommand<RadarListBox> ItemMouseEnterCommand { get; set; }

        public RadarItem()
        {
            ItemClickCommand = new RelayCommand<RadarListBox>(ItemClick_CallBack);
            ItemMouseEnterCommand = new RelayCommand<RadarListBox>(ItemMouseEnter_CallBack);
        }

        /// <summary>
        /// 雷达鼠标点击的事件
        /// </summary>
        /// <param name="obj"></param>
        private void ItemClick_CallBack(RadarListBox obj)
        {
            bool flag = IsValidRadarPopupItems(obj);
            if (!flag)
            {
                return;
            }
            RadarListClickRoutedEventArgs newEventArgs = new RadarListClickRoutedEventArgs(RadarListBox.RadarItemClickEvent, RadarPopupItems[0].CameraID);
            obj.RaiseEvent(newEventArgs);
        }

        /// <summary>
        /// 雷达鼠标移进的事件
        /// </summary>
        /// <param name="obj"></param>
        private void ItemMouseEnter_CallBack(RadarListBox obj)
        {
            bool flag = IsValidRadarPopupItems(obj);
            if (!flag)
            {
                return;
            }
            RadarListClickRoutedEventArgs newEventArgs = new RadarListClickRoutedEventArgs(RadarListBox.RadarItemMouseEnterEvent, RadarPopupItems[0].CameraID);
            obj.RaiseEvent(newEventArgs);
            //将当前选项与列表中最后一个项选项做交换
            var itemsSource = obj.ItemsSource as ObservableCollection<RadarItem>;
            int index = itemsSource.IndexOf(this);
            int lastIndex = itemsSource.Count - 1;
            var temp = itemsSource[index];
            itemsSource[index] = itemsSource[lastIndex];
            itemsSource[lastIndex] = temp;

        }

        /// <summary>
        /// 是否有效的雷达的点位对象
        /// </summary>
        /// <remarks>Added by wxh_2018_5_3</remarks>
        private bool IsValidRadarPopupItems(RadarListBox obj)
        {
            if (RadarPopupItems == null || obj == null)
            {
                return false;
            }
            if (RadarPopupItems.Count == 0)
            {
                return false;
            }
            // 点位不在线时, 点击事件无效
            if (!RadarPopupItems[0].IsOnline)
            {
                return false;
            }
            return true;
        }

        private double lng;
        /// <summary>
        /// 雷达点位经度
        /// </summary>
        public double Lng
        {
            get { return lng; }
            set { Set(() => Lng, ref lng, value); }
        }

        private double lat;
        /// <summary>
        /// 雷达点位纬度
        /// </summary>
        public double Lat
        {
            get { return lat; }
            set { Set(() => Lat, ref lat, value); }
        }


        private double relativeAzimuth;
        /// <summary>
        /// 当前点位与中心点位的相对角度
        /// 例如：正前方为337.5-22.5范围,右前方为22.5-67.5，正右方为67.5-112.5
        /// </summary>
        public double RelativeAzimuth
        {
            get { return relativeAzimuth; }
            set { Set(() => RelativeAzimuth, ref relativeAzimuth, value); }
        }

        private int distance;
        /// <summary>
        /// 当前点位离中心点位的距离
        /// </summary>
        public int Distance
        {
            get { return distance; }
            set { Set(() => Distance, ref distance, value); }
        }

        private ObservableCollection<RadarPopupItem> radarPopupItems = new ObservableCollection<RadarPopupItem>();
        /// <summary>
        /// 弹出的缩略图列表框,必须要先赋值
        /// </summary>
        public ObservableCollection<RadarPopupItem> RadarPopupItems
        {
            get { return radarPopupItems; }
            set { Set(() => RadarPopupItems, ref radarPopupItems, value); }
        }

    }
}
