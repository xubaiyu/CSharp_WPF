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

namespace WpfApplication3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string strNme = Environment.GetEnvironmentVariable("Platform");
            strNme = Environment.GetEnvironmentVariable("PlatformTarget");
            strNme = Environment.GetEnvironmentVariable("PlatformName");
            strNme = Environment.GetEnvironmentVariable("Configuration");
            strNme = Environment.GetEnvironmentVariable("Platform");
           Console.WriteLine(strNme);
        }
    }
}
