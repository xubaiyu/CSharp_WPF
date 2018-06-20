using ACMEControl.Args;
using ACMEControl.Controls;
using ACMEControl.Util;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace ACMEControl.Entity
{
    public class RadarPopupItem : ObservableObject
    {
        /// <summary>
        /// 点击缩略图时,进行视频联动处理
        /// </summary>
        public RelayCommand<object> ItemClickCommand { set; get; }

        public RadarPopupItem()
        {
            ItemClickCommand = new RelayCommand<object>(ItemClick_CallBack);
        }

        /// <summary>
        /// 缩略图的双击事件处理
        /// </summary>
        /// <param name="obj"></param>
        private void ItemClick_CallBack(object obj)
        {
            object[] tempObj = obj as object[];
            if (tempObj.Length == 2)
            {
                MouseButtonEventArgs args = tempObj[1] as MouseButtonEventArgs;

                // 捕获鼠标的双击事件
                if (args.ClickCount == 2)
                {
                    // 使用扩展RoutedEventArgs, 双击缩略图时,也能传递CameraID
                    RadarListClickRoutedEventArgs newEventArgs = new RadarListClickRoutedEventArgs(RadarListBox.RadarItemClickEvent, CameraID);
                    (tempObj[0] as RadarListBox).RaiseEvent(newEventArgs);
                }
            }
        }

        private bool isOnline;
        /// <summary>
        /// 雷达点位是否在线
        /// </summary>
        public bool IsOnline
        {
            get { return isOnline; }
            set { Set(() => IsOnline, ref isOnline, value); }
        }

        private string cameraID;

        /// <summary>
        /// 缩略图所指定的点位摄像头ID
        /// </summary>
        public string CameraID
        {
            get { return cameraID; }
            set { cameraID = value; }
        }

        private string cameraName;

        /// <summary>
        /// 缩略图所指定的点位摄像头名称
        /// </summary>
        public string CameraName
        {
            get { return cameraName; }
            set { Set(() => CameraName, ref cameraName, value); }
        }

        private string imagePath;
        /// <summary>
        /// 缩略图路径
        /// </summary>
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                RaisePropertyChanged(() => BitImageSource);
            }
        }

        private ImageSource bitImageSource = null;
        /// <summary>
        /// 缩略图资源
        /// </summary>
        public ImageSource BitImageSource
        {
            get
            {
                if (bitImageSource == null)
                {
                    return BitmapImageUtil.LoadBitmapImage(this.ImagePath, ResourcePath.ResourcePath.RadarDefaultPath);
                }

                return bitImageSource;
            }
        }

    }
}
