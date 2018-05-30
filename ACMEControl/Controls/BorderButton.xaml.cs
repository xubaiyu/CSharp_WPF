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
    /// 一般的边框按钮
    /// </summary>
    public class BorderButton : Button
    {
        static BorderButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderButton), new FrameworkPropertyMetadata(typeof(BorderButton)));
        }

        /// <summary>
        /// 边框的Data，矩形的时候可以填充RectangleGeometry
        /// </summary>
        public Geometry BorderData
        {
            get { return (Geometry)GetValue(BorderDataProperty); }
            set { SetValue(BorderDataProperty, value); }
        }

        public static readonly DependencyProperty BorderDataProperty =
            DependencyProperty.Register("BorderData", typeof(Geometry), typeof(BorderButton), new PropertyMetadata(null));


        /// <summary>
        /// 边框的边界颜色
        /// </summary>
        public Brush BorderStroke
        {
            get { return (Brush)GetValue(BorderStrokeProperty); }
            set { SetValue(BorderStrokeProperty, value); }
        }

        public static readonly DependencyProperty BorderStrokeProperty =
            DependencyProperty.Register("BorderStroke", typeof(Brush), typeof(BorderButton), new PropertyMetadata(null));

        /// <summary>
        /// 边框内部的填充
        /// </summary>
        public Brush BorderFill
        {
            get { return (Brush)GetValue(BorderFillProperty); }
            set { SetValue(BorderFillProperty, value); }
        }

        public static readonly DependencyProperty BorderFillProperty =
            DependencyProperty.Register("BorderFill", typeof(Brush), typeof(BorderButton), new PropertyMetadata(null));

        /// <summary>
        /// 中间图标的填充
        /// </summary>
        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }

        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(BorderButton), new PropertyMetadata(null));


        /// <summary>
        /// 中间图标填充遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
            DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(BorderButton), new PropertyMetadata(null));

        /// <summary>
        /// 距离中间位置
        /// </summary>
        public Thickness IconMargin
        {
            get { return (Thickness)GetValue(IconMarginProperty); }
            set { SetValue(IconMarginProperty, value); }
        }

        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(BorderButton), new PropertyMetadata(new Thickness(0,0,0,0)));
    }
}
