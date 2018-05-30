using ACMEControl.Args;
using ACMEControl.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using ACMEControl.Enum;

namespace ACMEControl.Entity
{
    public class FloatItem : ObservableObject
    {
        public RelayCommand<FloatListBox> ItemClickCommand { get; set; }
        public FloatItem()
        {
            ItemClickCommand = new RelayCommand<FloatListBox>(ItemClick_CallBack);
        }

        private void ItemClick_CallBack(FloatListBox obj)
        {
            FloatListClickRoutedEventArgs newEventArgs = new FloatListClickRoutedEventArgs(FloatListBox.FloatItemClickEvent, Content);
            obj.RaiseEvent(newEventArgs);
        }

        private Brush iconBrush;
        /// <summary>
        ///  图标的前景色
        /// </summary>
        public Brush IconBrush
        {
            get { return iconBrush; }
            set { Set(() => IconBrush, ref iconBrush, value); }
        }


        private Brush iconBrushMask;
        /// <summary>
        /// 图标的前景遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return iconBrushMask; }
            set { Set(() => IconBrushMask, ref iconBrushMask, value); }
        }

        private bool isEnable = true;
        /// <summary>
        /// 当前按钮是否可用
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnable; }
            set { Set(() => IsEnabled, ref isEnable, value); }
        }

        private string content;
        /// <summary>
        /// 按钮内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { Set(() => Content, ref content, value); }
        }


        private FloatControlType floatControlType;
        /// <summary>
        /// 浮动控件类型    建议弃用这个属性，改用IsChecked属性
        /// </summary>
        /// <remarks>added by gt for PBI-A3160 20180522</remarks>
        public FloatControlType FloatControlType
        {
            get { return floatControlType; }
            set { Set(() => FloatControlType, ref floatControlType, value); }
        }

        private bool? isFaceVisible;
        /// <summary>
        /// 人脸窗口是否可见
        /// </summary>
        public bool? IsFaceVisible
        {
            get { return isFaceVisible; }
            set { Set(() => IsFaceVisible, ref isFaceVisible, value); }
        }

        /// <summary>
        /// 选中状态
        /// </summary>
        /// <remarks>[PBI_A3145] 自动立体化联动（博聪） Addedd by DHT_20180525</remarks>
        private bool? isChecked;

        /// <summary>
        /// 选中状态
        /// </summary>
        /// <remarks>[PBI_A3145] 自动立体化联动（博聪） Addedd by DHT_20180525</remarks>
        public bool? IsChecked
        {
            get { return isChecked; }
            set { Set(() => IsChecked, ref isChecked, value); }
        }
    }
}
