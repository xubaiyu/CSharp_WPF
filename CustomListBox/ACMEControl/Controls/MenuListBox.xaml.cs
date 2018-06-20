using ACMEControl.Args;
using ACMEControl.Entity;
using ACMEControl.RountedEventHandle;
using ACMEControl.Util;
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
    /// 二级菜单弹出框列表
    /// </summary>
    public class MenuListBox : ListBox
    {
        static MenuListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuListBox), new FrameworkPropertyMetadata(typeof(MenuListBox)));
        }

        public static readonly RoutedEvent MenuListBoxSelectionChangedEvent = EventManager.RegisterRoutedEvent(
 "MenuListBoxSelectionChanged", RoutingStrategy.Bubble, typeof(MenuListClickRoutedEventHandle), typeof(MenuListBox));

        /// <summary>
        /// 二级菜单弹出框列表的选择事件
        /// </summary>
        public event MenuListClickRoutedEventHandle MenuListBoxSelectionChanged
        {
            add { this.AddHandler(MenuListBoxSelectionChangedEvent, value); }
            remove { this.RemoveHandler(MenuListBoxSelectionChangedEvent, value); }
        }

        public static readonly RoutedEvent MenuPopupItemClickEvent = EventManager.RegisterRoutedEvent(
  "MenuPopupItemClick", RoutingStrategy.Bubble, typeof(MenuListClickRoutedEventHandle), typeof(MenuListBox));

        /// <summary>
        /// 二级菜单弹出框列表的点击事件
        /// </summary>
        public event MenuListClickRoutedEventHandle MenuPopupItemClick
        {
            add { this.AddHandler(MenuPopupItemClickEvent, value); }
            remove { this.RemoveHandler(MenuPopupItemClickEvent, value); }
        }

        public static readonly RoutedEvent MenuListItemClickEvent = EventManager.RegisterRoutedEvent(
 "MenuListItemClick", RoutingStrategy.Bubble, typeof(MenuClickRoutedEventHandle), typeof(MenuListBox));

        /// <summary>
        /// 二级菜单弹出框menuPopupBox的点击事件，当没有下拉列表时才会触发
        /// </summary>
        public event MenuClickRoutedEventHandle MenuListItemClick
        {
            add { this.AddHandler(MenuListItemClickEvent, value); }
            remove { this.RemoveHandler(MenuListItemClickEvent, value); }
        }
    }
}
