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

namespace CustomListBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Floor> a = new List<Floor>();
            for (int i = 20; i > 0; i--)
            {
                a.Add(new Floor()
                {floorName =  i+"层",floorId = i+""}
                );
               

            }

            DataTable floors = new DataTable();
            floors.Columns.Add("FloorName");
            floors.Columns.Add("floorId");

            for (int i = 0; i < 2; i++)
            {
                floors.Rows.Add( i + "层", i+"");

            }

            

            myListBox.ItemsSource = a;
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
