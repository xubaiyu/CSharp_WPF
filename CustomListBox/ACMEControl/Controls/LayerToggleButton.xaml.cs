using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// 一般的checkbox
    /// </summary>
    public class LayerToggleButton :CheckBox
    {
        static LayerToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayerToggleButton), new FrameworkPropertyMetadata(typeof(LayerToggleButton)));
        }

        /// <summary>
        /// 图标的遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
            DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(LayerToggleButton), new PropertyMetadata(null));
    }
}
