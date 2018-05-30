using ACMEControl.Args;
using ACMEControl.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ACMEControl.Entity
{
    public class MenuPopupItem : ObservableObject
    {
        public RelayCommand<MenuPopupBox> ItemClickCommand { get; set; }
        public MenuPopupItem()
        {
            ItemClickCommand = new RelayCommand<MenuPopupBox>(ItemClick_CallBack);
        }

        private void ItemClick_CallBack(MenuPopupBox obj)
        {
            MenuClickRoutedEventArgs newEventArgs = new MenuClickRoutedEventArgs(MenuPopupBox.MenuPopupItemClickEvent, Text);
            obj.RaiseEvent(newEventArgs);
        }

        private Brush menuIcon;
        /// <summary>
        /// 菜单项前面图标
        /// </summary>
        public Brush MenuIcon
        {
            get { return menuIcon; }
            set { Set(() => MenuIcon, ref menuIcon, value); }
        }

        private string text;
        /// <summary>
        /// 菜单项文字
        /// </summary>
        public string Text
        {
            get { return text; }
            set { Set(() => Text, ref text, value); }
        }
    }
}
