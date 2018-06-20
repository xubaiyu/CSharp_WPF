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
    /// 一般的checkbox
    /// </summary>
    public class LayerCheckBox : CheckBox
    {
        static LayerCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayerCheckBox), new FrameworkPropertyMetadata(typeof(LayerCheckBox)));
        }
    }
}
