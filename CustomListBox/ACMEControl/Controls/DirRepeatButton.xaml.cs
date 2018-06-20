using ACMEControl.Enum;
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
    /// 滚动条上下左右四个方向按钮repeatButton
    /// </summary>
    public class DirRepeatButton : RepeatButton
    {
        static DirRepeatButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DirRepeatButton), new FrameworkPropertyMetadata(typeof(DirRepeatButton)));
        }

        /// <summary>
        /// 方向(上下左右)
        /// </summary>
        public DirectionEnum Direction
        {
            get { return (DirectionEnum)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(DirectionEnum), typeof(DirRepeatButton), new PropertyMetadata(DirectionEnum.Down));
    }
}
