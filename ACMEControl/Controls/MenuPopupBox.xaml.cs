using ACMEControl.Args;
using ACMEControl.Entity;
using ACMEControl.Enum;
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
    /// 二级菜单弹出框
    /// </summary>
    public class MenuPopupBox : ComboBox
    {
        static MenuPopupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuPopupBox), new FrameworkPropertyMetadata(typeof(MenuPopupBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ControlTemplate template = this.Template as ControlTemplate;
            Border bd = template.FindName("downBorder", this) as Border;
            bd.Height = this.Items.Count * 25 + 2;
            this.SelectionChanged += MenuPopupBox_SelectionChanged;
        }

        private void MenuPopupBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuPopupBox menuPopupBox = (MenuPopupBox)sender;
            MenuPopupItem item = menuPopupBox.SelectedItem as MenuPopupItem;
            if (item == null)
                return;
            MenuClickRoutedEventArgs newEventArgs = new MenuClickRoutedEventArgs(MenuPopupBox.MenuPopupSelectionChangedEvent, item.Text);
            this.RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent MenuPopupSelectionChangedEvent = EventManager.RegisterRoutedEvent(
 "MenuPopupSelectionChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuPopupBox));

        /// <summary>
        /// 二级菜单弹出框的选择事件
        /// </summary>
        public event RoutedEventHandler MenuPopupSelectionChanged
        {
            add { this.AddHandler(MenuPopupSelectionChangedEvent, value); }
            remove { this.RemoveHandler(MenuPopupSelectionChangedEvent, value); }
        }


        public static readonly RoutedEvent MenuPopupItemClickEvent = EventManager.RegisterRoutedEvent(
   "MenuPopupItemClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MenuPopupBox));

        /// <summary>
        /// 二级菜单弹出框的点击事件
        /// </summary>
        public event RoutedEventHandler MenuPopupItemClick
        {
            add { this.AddHandler(MenuPopupItemClickEvent, value); }
            remove { this.RemoveHandler(MenuPopupItemClickEvent, value); }
        }
        /// <summary>
        /// 图标的前景色
        /// </summary>
        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }
        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(MenuPopupBox), new PropertyMetadata(null));

        /// <summary>
        /// 图标的前景遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
            DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(MenuPopupBox), new PropertyMetadata(null));

        public string MenuPopupText
        {
            get { return (string)GetValue(MenuPopupTextProperty); }
            set { SetValue(MenuPopupTextProperty, value); }
        }

        public static readonly DependencyProperty MenuPopupTextProperty =
            DependencyProperty.Register("MenuPopupText", typeof(string), typeof(MenuPopupBox), new PropertyMetadata(null));
    }
}
