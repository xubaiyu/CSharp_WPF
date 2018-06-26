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
    public class RoomLayerRadioButton : RadioButton
    {
        static RoomLayerRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoomLayerRadioButton), new FrameworkPropertyMetadata(typeof(RoomLayerRadioButton)));
        }

        /// <summary>
        /// 背景是否显示
        /// </summary>
        public bool BackOpacity
        {
            get { return (bool)GetValue(BackOpacityProperty); }
            set { SetValue(BackOpacityProperty, value); }
        }

        public static readonly DependencyProperty BackOpacityProperty =
            DependencyProperty.Register("BackOpacity", typeof(bool), typeof(RoomLayerRadioButton), new PropertyMetadata(true));

        /// <summary>
        /// 图标的颜色
        /// </summary>
        public Brush IconBrush
        {
            get { return (Brush)GetValue(IconBrushProperty); }
            set { SetValue(IconBrushProperty, value); }
        }

        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(RoomLayerRadioButton), new PropertyMetadata(null));

        /// <summary>
        /// 图标的遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
            DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(RoomLayerRadioButton), new PropertyMetadata(null));
    }
}
