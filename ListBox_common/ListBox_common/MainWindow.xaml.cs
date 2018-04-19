using System;
using System.Collections.Generic;
using System.Data;
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

namespace ListBox_common
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

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable pic = new DataTable();
            pic.Columns.Add("name");
            pic.Columns.Add("no");
            pic.Rows.Add(@"张三", "1");
            pic.Rows.Add(@"李四", "2");
            pic.Rows.Add(@"王五", "3");
            pic.Rows.Add(@"赵六", "4");
            pic.Rows.Add(@"王安", "5");
            pic.Rows.Add(@"张节", "6");
            pic.Rows.Add(@"王望", "7");

            this.PersonsListBox.ItemsSource = pic.DefaultView;

        }
    }
}
