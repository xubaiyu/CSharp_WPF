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
    /// 右侧toolbar checkbox
    /// </summary>
    public class ToolBarCheckBox : CheckBox
    {
        static ToolBarCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToolBarCheckBox), new FrameworkPropertyMetadata(typeof(ToolBarCheckBox)));
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
            DependencyProperty.Register("BackgroundMask", typeof(Brush), typeof(ToolBarCheckBox), new PropertyMetadata(null));
    }
}
