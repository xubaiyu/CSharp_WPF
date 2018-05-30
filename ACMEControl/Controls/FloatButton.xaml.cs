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
    /// 浮动工具栏按钮
    /// </summary>
    public class FloatButton : Button
    {
        static FloatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatButton), new FrameworkPropertyMetadata(typeof(FloatButton)));
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
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(FloatButton), new PropertyMetadata(null));

        /// <summary>
        /// 图标的前景遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
           DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(FloatButton), new PropertyMetadata(null));
    }
}
