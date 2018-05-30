using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACMEControl.Args
{
    public class MenuClickRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// 选择的菜单项文字
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        public MenuClickRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        /// <param name="text">选择的菜单项文字</param>
        public MenuClickRoutedEventArgs(RoutedEvent routedEvent, string text) : base(routedEvent)
        {
            Text = text;
        }
    }
}
