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
    ///一般的通用按钮
    /// </summary>
    public class ComButton : Button
    {
        static ComButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComButton), new FrameworkPropertyMetadata(typeof(ComButton)));
        }
    }
}
