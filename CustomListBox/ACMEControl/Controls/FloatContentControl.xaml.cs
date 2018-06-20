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
using ACMEControl.Enum;

namespace ACMEControl.Controls
{
    /// <summary>
    /// FloatContentControl.xaml 的交互逻辑
    /// </summary>
    public  class FloatContentControl : ContentControl
    {
        static FloatContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatContentControl), new FrameworkPropertyMetadata(typeof(FloatContentControl)));
        }

        /// <summary>
        /// 内容控件类型
        /// </summary>
        public FloatControlType FloatControlType
        {
            get { return (FloatControlType)GetValue(FloatControlTypeProperty); }
            set { SetValue(FloatControlTypeProperty, value); }
        }

        public static readonly DependencyProperty FloatControlTypeProperty =
            DependencyProperty.Register("FloatControlType", typeof(FloatControlType), typeof(FloatContentControl), new PropertyMetadata(FloatControlType.Btn));
    }
}
