using ACMEControl.Args;
using ACMEControl.Controls;
using ACMEControl.Enum;
using ACMEControl.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ACMEControl.Entity
{
    /// <summary>
    /// 树形控件数据项
    /// </summary>
    public class CameraTreeNode: ObservableObject,ICloneable
    {
        public RelayCommand<object> MouseLeftButtonDownCommand { private set; get; }
        public CameraTreeNode()
        {
            MouseLeftButtonDownCommand = new RelayCommand<object>(MouseLeftButtonDown_CallBack);
        }

        private void MouseLeftButtonDown_CallBack(object obj)
        {
            object[] tempObj = obj as object[];
            MouseButtonEventArgs args = tempObj[1] as MouseButtonEventArgs;
            if (tempObj.Length == 2)
            {
                CameraTreeRoutedEventArgs clickEventArgs = new CameraTreeRoutedEventArgs(CameraTreeView.TreeItemClickEvent, this);
                (tempObj[0] as CameraTreeView).RaiseEvent(clickEventArgs);
                if (args.ClickCount == 2)
                {
                    CameraTreeRoutedEventArgs doubleClickEventArgs = new CameraTreeRoutedEventArgs(CameraTreeView.TreeItemDoubleClickEvent, this);
                    (tempObj[0] as CameraTreeView).RaiseEvent(doubleClickEventArgs);
                }
            }
        }

        /// <summary>
        /// 树的唯一标签，根据GUID来生成
        /// </summary>
        public string GUID { get; set; }

        private CameraType cameraType;
        /// <summary>
        /// 摄像机类型
        /// </summary>
        public CameraType CameraType
        {
            get { return cameraType; }
            set { Set(() => CameraType, ref cameraType, value); }
        }

        private bool isOnline;
        /// <summary>
        /// 摄像机状态(是否在线)
        /// </summary>
        public bool IsOnLine
        {
            get { return isOnline; }
            set { Set(() => IsOnLine, ref isOnline, value); }
        }

        private bool isExpanded = true;
        /// <summary>
        /// 当前树形节点是否展开
        /// </summary>
        public bool IsExpanded
        {
            get { return isExpanded; }
            set { Set(() => IsExpanded, ref isExpanded, value); }
        }

        /// <summary>
        /// 当前节点的父节点
        /// </summary>
        public CameraTreeNode Parent { get; set; }

        private string cameraName;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string CameraName
        {
            get { return cameraName; }
            set { Set(() => CameraName, ref cameraName, value); }
        }

        /// <summary>
        /// 摄像机ID
        /// </summary>
        public string CameraID { get; set; }

        private ObservableCollection<CameraTreeNode> subNodeList = new ObservableCollection<CameraTreeNode>();
        /// <summary>
        /// 当前节点的子节点
        /// </summary>
        public ObservableCollection<CameraTreeNode> SubNodeList
        {
            get { return subNodeList; }
            set { Set(() => SubNodeList, ref subNodeList, value); }
        }

        public object Clone()
        {
            CameraTreeNode node = new CameraTreeNode();
            node.GUID = this.GUID;
            node.CameraName = this.CameraName;
            node.CameraID = this.CameraID;
            node.IsOnLine = this.IsOnLine;
            node.CameraType = this.CameraType;
            return node;
        }
    }
}
