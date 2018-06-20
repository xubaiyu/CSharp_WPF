using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACMEControl.Args
{
    public class MenuListClickRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// 弹出菜单项文字
        /// </summary>
        public string MenuText { get; set; }
        /// <summary>
        /// Combox的功能名称,MenuList每一个item是一个combobox
        /// </summary>
        public string MenuListItemText { get; set; }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        public MenuListClickRoutedEventArgs(RoutedEvent routedEvent):base(routedEvent)
        {

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        /// <param name="text">选择的菜单项文字</param>
        public MenuListClickRoutedEventArgs(RoutedEvent routedEvent, string menuText, string menuListItemText) : base(routedEvent)
        {
            MenuText = menuText;
            MenuListItemText = menuListItemText;
        }
    }
}
