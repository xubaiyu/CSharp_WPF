using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ACMEControl.Args
{
    public class RadarListClickRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// 摄像头ID
        /// </summary>
        public string CamerID { get; set; }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        public RadarListClickRoutedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {

        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="routedEvent"></param>
        /// <param name="cameraID">摄像头ID</param>
        public RadarListClickRoutedEventArgs(RoutedEvent routedEvent, string cameraID) : base(routedEvent)
        {
            CamerID = cameraID;
        }
    }
}
