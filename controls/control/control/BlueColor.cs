using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Vimicro.Ga.Styles
{
    public class BlueColor : BaseColor
    {
        protected override Brush LeftBarCanvas_mousedownmove()
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#CC00E1FF"));
        }

        protected override Brush LeftBarCanvas_mouseleave()
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7200E1FF"));
        }
    }
}
