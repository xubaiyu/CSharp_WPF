using ACMEControl.Args;
using ACMEControl.Controls;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMEControl.RountedArgsConverter
{
    public class MenuClickRoutedEventArgsToTuple : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var args = (MenuClickRoutedEventArgs)value;
            var element = (MenuListBox)parameter;


            return new Tuple<MenuClickRoutedEventArgs, MenuListBox>(args, element);
        }
    }
}
