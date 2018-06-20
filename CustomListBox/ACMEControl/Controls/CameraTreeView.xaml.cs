using ACMEControl.Args;
using ACMEControl.Entity;
using ACMEControl.Model;
using ACMEControl.RountedEventHandle;
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
    /// 一般的边框按钮
    /// </summary>
    public class CameraTreeView : TreeView
    {
        static CameraTreeView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CameraTreeView), new FrameworkPropertyMetadata(typeof(CameraTreeView)));
        }

        public override void OnApplyTemplate()
        {
            this.SelectedItemChanged += CameraTreeView_SelectedItemChanged;
        }

        private void CameraTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            CameraTreeNode node = e.NewValue as CameraTreeNode;
            if (node != null)
            {
                CameraTreeRoutedEventArgs newEventArgs = new CameraTreeRoutedEventArgs(CameraTreeView.TreeViewSelectionChangedEvent, node);
                this.RaiseEvent(newEventArgs);
            }
        }

        public static readonly RoutedEvent TreeItemClickEvent = EventManager.RegisterRoutedEvent(
"TreeItemClick", RoutingStrategy.Bubble, typeof(CameraTreeRoutedEventHandle), typeof(CameraTreeView));

        /// <summary>
        /// 树形控件的点击
        /// </summary>
        public event CameraTreeRoutedEventHandle TreeItemClick
        {
            add { this.AddHandler(TreeItemClickEvent, value); }
            remove { this.RemoveHandler(TreeItemClickEvent, value); }
        }

        public static readonly RoutedEvent TreeItemDoubleClickEvent = EventManager.RegisterRoutedEvent(
"TreeItemDoubleClick", RoutingStrategy.Bubble, typeof(CameraTreeRoutedEventHandle), typeof(CameraTreeView));

        /// <summary>
        /// 树形控件的双击
        /// </summary>
        public event CameraTreeRoutedEventHandle TreeItemDoubleClick
        {
            add { this.AddHandler(TreeItemDoubleClickEvent, value); }
            remove { this.RemoveHandler(TreeItemDoubleClickEvent, value); }
        }

        public static readonly RoutedEvent TreeViewSelectionChangedEvent = EventManager.RegisterRoutedEvent(
"TreeViewSelectionChanged", RoutingStrategy.Bubble, typeof(CameraTreeRoutedEventHandle), typeof(CameraTreeView));

        /// <summary>
        /// 树的选择事件
        /// </summary>
        public event CameraTreeRoutedEventHandle TreeViewSelectionChanged
        {
            add { this.AddHandler(TreeViewSelectionChangedEvent, value); }
            remove { this.RemoveHandler(TreeViewSelectionChangedEvent, value); }
        }

    }
}
