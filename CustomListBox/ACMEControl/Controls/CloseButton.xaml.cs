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
    ///关闭按钮
    /// </summary>
    public class CloseButton : Button
    {
        static CloseButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CloseButton), new FrameworkPropertyMetadata(typeof(CloseButton)));
        }

        /// <summary>
        /// 关闭x的大小
        /// </summary>
        public double CloseFontSize
        {
            get { return (double)GetValue(CloseFontSizeProperty); }
            set { SetValue(CloseFontSizeProperty, value); }
        }

        public static readonly DependencyProperty CloseFontSizeProperty =
            DependencyProperty.Register("CloseFontSize", typeof(double), typeof(CloseButton), new PropertyMetadata(0.0));

        /// <summary>
        /// 距离边界距离
        /// </summary>
        public double BorderDistance
        {
            get { return (double)GetValue(BorderDistanceProperty); }
            set { SetValue(BorderDistanceProperty, value); }
        }

        public static readonly DependencyProperty BorderDistanceProperty =
            DependencyProperty.Register("BorderDistance", typeof(double), typeof(CloseButton), new PropertyMetadata(0.0));

        /// <summary>
        /// 关闭按钮的位置
        /// </summary>
        public CloseDirEnum CloseDirEnum
        {
            get { return (CloseDirEnum)GetValue(CloseDirEnumProperty); }
            set { SetValue(CloseDirEnumProperty, value); }
        }

        public static readonly DependencyProperty CloseDirEnumProperty =
            DependencyProperty.Register("CloseDirEnum", typeof(CloseDirEnum), typeof(CloseButton), new PropertyMetadata(CloseDirEnum.LeftUp));

    }
}
