using ACMEControl.Args;
using ACMEControl.Controls;
using ACMEControl.Enum;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ACMEControl.Entity
{
    public class MenuListItem : ObservableObject
    {
        public RelayCommand<Tuple<MenuClickRoutedEventArgs, MenuListBox>> ItemClickCommand { private set; get; }
        public RelayCommand<MenuListBox> MenuPopupBoxClickCommand { private set; get; }
        public RelayCommand<object> MenuPopupSelectionChangedCommand { private set; get; }
        public MenuListItem()
        {
            ItemClickCommand = new RelayCommand<Tuple<MenuClickRoutedEventArgs, MenuListBox>>(ItemClick_CallBack);
            MenuPopupBoxClickCommand = new RelayCommand<MenuListBox>(MenuPopupBoxClick_CallBack);
            MenuPopupSelectionChangedCommand = new RelayCommand<object>(MenuPopupSelectionChanged_CallBack);
        }

        private void MenuPopupSelectionChanged_CallBack(object obj)
        {
            object[] tempObj = obj as object[];
            if (tempObj.Length == 2)
            {
                MenuClickRoutedEventArgs args = tempObj[1] as MenuClickRoutedEventArgs;
                string menuText = args.Text;
                string menuListText = Text;
                MenuListClickRoutedEventArgs newEventArgs = new MenuListClickRoutedEventArgs(MenuListBox.MenuListBoxSelectionChangedEvent, menuText, menuListText);
                (tempObj[0] as MenuListBox).RaiseEvent(newEventArgs);
            }
        }

        private void MenuPopupBoxClick_CallBack(MenuListBox obj)
        {
            if (MenuPopupItems.Count > 0)
                return;
            IsDropDownOpen = false;
            MenuClickRoutedEventArgs newEventArgs = new MenuClickRoutedEventArgs(MenuListBox.MenuListItemClickEvent, Text);
            obj.RaiseEvent(newEventArgs);
        }

        private void ItemClick_CallBack(Tuple<MenuClickRoutedEventArgs, MenuListBox> obj)
        {
            MenuListClickRoutedEventArgs newEventArgs = new MenuListClickRoutedEventArgs(MenuListBox.MenuPopupItemClickEvent, obj.Item1.Text, Text);
            obj.Item2.RaiseEvent(newEventArgs);
        }

        private string text;
        /// <summary>
        /// MenuListBox的每一个Combobox的Text值
        /// </summary>
        public string Text
        {
            get { return text; }
            set { Set(() => Text, ref text, value); }
        }

        private Brush iconBrush;
        /// <summary>
        ///  图标的前景色
        /// </summary>
        public Brush IconBrush
        {
            get { return iconBrush; }
            set { Set(() => IconBrush, ref iconBrush, value); }
        }


        private Brush iconBrushMask;
        /// <summary>
        /// 图标的前景遮罩
        /// </summary>
        public Brush IconBrushMask
        {
            get { return iconBrushMask; }
            set { Set(() => IconBrushMask, ref iconBrushMask, value); }
        }

        private ObservableCollection<MenuPopupItem> menuPopupItems = new ObservableCollection<MenuPopupItem>();
        /// <summary>
        /// 弹出的菜单项
        /// </summary>
        public ObservableCollection<MenuPopupItem> MenuPopupItems
        {
            get { return menuPopupItems; }
            set { Set(() => MenuPopupItems, ref menuPopupItems, value); }
        }

        private bool isDropDownOpen;
        /// <summary>
        /// 弹出框是否打开，在没有下拉列表情况下，点击item，关闭弹出框
        /// </summary>
        public bool IsDropDownOpen
        {
            get { return isDropDownOpen; }
            set { Set(() => IsDropDownOpen, ref isDropDownOpen, value); }
        }

        private bool isEnable = true;
        /// <summary>
        /// 当前Combobox是否可用
        /// </summary>
        public bool IsEnabled
        {
            get { return isEnable; }
            set { Set(() => IsEnabled, ref isEnable, value); }
        }

    }
}
