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
    /// 雷达点位按钮样式
    /// </summary>
    public partial class RadarButton : Button
    {
        static RadarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadarButton), new FrameworkPropertyMetadata(typeof(RadarButton)));
        }

        /// <summary>
        /// 雷达点位是否在线
        /// </summary>
        public bool IsOnline
        {
            get { return (bool)GetValue(IsOnlineProperty); }
            set { SetValue(IsOnlineProperty, value); }
        }

        public static readonly DependencyProperty IsOnlineProperty =
            DependencyProperty.Register("IsOnline", typeof(bool), typeof(RadarButton), new PropertyMetadata(true));
    }
}
