using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace ACMEControl.Util
{
    public class BitmapImageUtil
    {
        /// <summary>
        /// 加载图片资源
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="defaultUrl">雷达点位的默认缩略图</param>
        /// <returns></returns>
        public static BitmapImage LoadBitmapImage(string uri, string defaultUrl)
        {

            uri = string.IsNullOrEmpty(uri) ? string.Format("pack://application:,,,/ACMEControl;component/{0}", defaultUrl) : uri;
            BitmapImage src = null;

            try
            {
                src = new BitmapImage();
                src.BeginInit();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.CreateOptions = BitmapCreateOptions.None;
                src.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
                src.EndInit();

            }
            catch (Exception ex)
            {
                src = new BitmapImage();
                src.BeginInit();
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.CreateOptions = BitmapCreateOptions.None;
                src.UriSource = new Uri(string.Format("pack://application:,,,/ACMEControl;component/{0}", defaultUrl), UriKind.RelativeOrAbsolute);
                src.EndInit();
            }

            return src;
        }
    }
}
