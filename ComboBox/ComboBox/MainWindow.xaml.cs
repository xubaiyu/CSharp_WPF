using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ComboBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<BuildingFloorNo> alist = new ObservableCollection<BuildingFloorNo>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            alist.Add(new BuildingFloorNo { FloorNo = -1 });
            alist.Add(new BuildingFloorNo { FloorNo = 1 });
            alist.Add(new BuildingFloorNo { FloorNo = 2 });
            alist.Add(new BuildingFloorNo { FloorNo = 3 });
            alist.Add(new BuildingFloorNo { FloorNo = 4 });
            my.ItemsSource = alist;
           
        }

    }

    public class BuildingFloorNo 
    {      
        public int FloorNo
        { 
            get;
            set;
            
        }
         
    }
}
