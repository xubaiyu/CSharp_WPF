using ACMEControl.Entity;
using ACMEControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACMEControl.Args
{
    public class CameraTreeRoutedEventArgs: RoutedEventArgs
    {
        /// <summary>
        /// 选择的树节点信息
        /// </summary>
        public CameraTreeNode CameraTreeNode { get; set; }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        public CameraTreeRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        /// <param name="content">选择的树节点信息</param>
        public CameraTreeRoutedEventArgs(RoutedEvent routedEvent, CameraTreeNode cameraTreeNode) : base(routedEvent)
        {
            CameraTreeNode = cameraTreeNode;
        }
    }
}
