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
    /// 浮动工具栏列表
    /// </summary>
    public class FloatListBox : ItemsControl
    {
        static FloatListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatListBox), new FrameworkPropertyMetadata(typeof(FloatListBox)));
        }

        public static readonly RoutedEvent FloatItemClickEvent = EventManager.RegisterRoutedEvent(
"FloatItemClick", RoutingStrategy.Bubble, typeof(FloatListClickRoutedEventHandle), typeof(FloatListBox));

        /// <summary>
        /// 浮动工具栏列表的点击事件
        /// </summary>
        public event FloatListClickRoutedEventHandle FloatItemClick
        {
            add { this.AddHandler(FloatItemClickEvent, value); }
            remove { this.RemoveHandler(FloatItemClickEvent, value); }
        }
    }
}
