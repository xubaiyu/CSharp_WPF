using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication104
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabHeader_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabHeader.SelectedIndex == 0)
            {
                InformationDeviceTree.Visibility = System.Windows.Visibility.Visible;
                searchGrid.Visibility = System.Windows.Visibility.Visible;
                searchSvacGrid.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                InformationDeviceTree.Visibility = System.Windows.Visibility.Hidden;
                searchGrid.Visibility = System.Windows.Visibility.Hidden;
                searchSvacGrid.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }


    class LexicographicalConverter2 : IValueConverter
    {
        protected Dictionary<string, ListCollectionView> m_NormalListViewMap = new Dictionary<string, ListCollectionView>(); //普通设备列表

        public LexicographicalConverter2() { }

        static LexicographicalConverter2()
        {
            Instance = new LexicographicalConverter2();
        }

        public static LexicographicalConverter2 Instance
        {
            get;
            set;
        }


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Collections.IList collection = value as System.Collections.IList;

            string curId = "";
          

            if (m_NormalListViewMap.ContainsKey(curId))
                return m_NormalListViewMap[curId];

          
           

           

            return curId;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
