using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACMEControl.Args
{
    public class FloatListClickRoutedEventArgs: RoutedEventArgs
    {
        /// <summary>
        /// 选择的菜单项文字
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        public FloatListClickRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        /// <param name="content">选择的菜单项文字</param>
        public FloatListClickRoutedEventArgs(RoutedEvent routedEvent, string content) : base(routedEvent)
        {
            Content = content;
        }
    }
}
