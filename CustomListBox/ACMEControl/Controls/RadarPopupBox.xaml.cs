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
    /// 雷达点位缩略图弹出框
    /// </summary>
    public class RadarPopupBox : ListBox
    {
        static RadarPopupBox()
        {
            // [说明]
            // 无外观的控件需要在静态构造函数中设置DefaultStyleKeyProperty,
            // 这样它会去在themes /generic.xaml的文件获取默认的样式。
            // 查找RadarPopupBox的ThemeStyle使用的键值从{x:Type ComboBox}被改成了{x:Type RadarPopupBox}
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadarPopupBox), new FrameworkPropertyMetadata(typeof(RadarPopupBox)));
        }

        public event RoutedEventHandler RadarItemClick
        {
            add { this.AddHandler(RadarItemClickEvent, value); }
            remove { this.RemoveHandler(RadarItemClickEvent, value); }
        }

        public static readonly RoutedEvent RadarItemClickEvent = EventManager.RegisterRoutedEvent(
            "RadarItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RadarPopupBox));
    }
}
