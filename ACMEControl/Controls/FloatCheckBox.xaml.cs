﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACMEControl.Controls
{
    //作者		：gt
    //创建时间	：2018-05-22
    //修改人	：
    //描述	    ：人脸业务
    //功能		：PBI_A3160: 人脸业务（一）
    /// <summary>
    /// 浮动工具栏列表(CheckBox)
    /// </summary>
    public class FloatCheckBox : CheckBox
    {
        static FloatCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatCheckBox), new FrameworkPropertyMetadata(typeof(FloatCheckBox)));
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
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(FloatCheckBox), new PropertyMetadata(null));

        /// <summary>
        /// 图标的前景遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return (Brush)GetValue(IconBrushMaskProperty); }
            set { SetValue(IconBrushMaskProperty, value); }
        }

        public static readonly DependencyProperty IconBrushMaskProperty =
            DependencyProperty.Register("IconBrushMask", typeof(Brush), typeof(FloatCheckBox), new PropertyMetadata(null));
    }
}