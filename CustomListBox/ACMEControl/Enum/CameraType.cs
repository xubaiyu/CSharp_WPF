using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACMEControl.Enum
{
    /// <summary>
    /// 摄像机类型
    /// </summary>
    public enum CameraType
    {
        /// <summary>
        /// 枪机, 1
        /// </summary>
        Gun = 1,
        /// <summary>
        /// 球机, 3
        /// </summary>
        Ball = 3,
        /// <summary>
        /// 一体机, 7
        /// </summary>
        OneAll = 7,
        /// <summary>
        /// 星光, 99
        /// </summary>
        StarLight = 99,
        /// <summary>
        /// 高点枪, 100 
        /// </summary>
        HightGun = 100,
        /// <summary>
        /// 卡口, 103
        /// </summary>
        Bayonet = 103, 
    }
}
