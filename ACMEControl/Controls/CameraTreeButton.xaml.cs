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
    //摄像机按钮
    /// </summary>
    public class CameraTreeButton : Button
    {
        static CameraTreeButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraTreeButton), new FrameworkPropertyMetadata(typeof(CameraTreeButton)));
        }

        /// <summary>
        /// 摄像机类型
        /// </summary>
        public CameraType CameraType
        {
            get { return (CameraType)GetValue(CameraTypeProperty); }
            set { SetValue(CameraTypeProperty, value); }
        }
        public static readonly DependencyProperty CameraTypeProperty =
            DependencyProperty.Register("CameraType", typeof(CameraType), typeof(CameraTreeButton), new PropertyMetadata(CameraType.Gun));

        /// <summary>
        /// 摄像机状态是否在线
        /// </summary>
        public bool IsOnLine
        {
            get { return (bool)GetValue(IsOnLineProperty); }
            set { SetValue(IsOnLineProperty, value); }
        }
        public static readonly DependencyProperty IsOnLineProperty =
            DependencyProperty.Register("IsOnLine", typeof(bool), typeof(CameraTreeButton), new PropertyMetadata(true));
    }
}
