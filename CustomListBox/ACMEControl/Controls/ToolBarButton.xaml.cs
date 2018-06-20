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
    /// 右侧toolbar按钮
    /// </summary>
    public class ToolBarButton : Button
    {
        static ToolBarButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarButton), new FrameworkPropertyMetadata(typeof(ToolBarButton)));
        }

        /// <summary>
        /// 背景图标的遮罩
        /// </summary>
        public Brush BackgroundMask
        {
            get { return (Brush)GetValue(BackgroundMaskProperty); }
            set { SetValue(BackgroundMaskProperty, value); }
        }

        public static readonly DependencyProperty BackgroundMaskProperty =
            DependencyProperty.Register("BackgroundMask", typeof(Brush), typeof(ToolBarButton), new PropertyMetadata(null));
    }
}
