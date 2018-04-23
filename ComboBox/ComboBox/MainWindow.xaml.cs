using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace BuildingFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 楼层
        ObservableCollection<BuildingFloorNo> alist = new ObservableCollection<BuildingFloorNo>();
        // 楼层-户
        Dictionary<int, DataTable> floorRoomsDict = new Dictionary<int, DataTable>();
        // 户-居民
        Dictionary<string, ObservableCollection<Customer>> RoomResidents = new Dictionary<string, ObservableCollection<Customer>>();
        public MainWindow()
        {
            InitializeComponent();
        }
        CollectionViewSource view = new CollectionViewSource();
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        int currentPageIndex = 0;
        int itemPerPage = 20;
        int totalPage = 0;

        private void ShowCurrentPageIndex()
        {
           // this.tbCurrentPage.Text = (currentPageIndex + 1).ToString();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            alist.Add(new BuildingFloorNo { FloorNo = -1 });
            alist.Add(new BuildingFloorNo { FloorNo = 1 });
            alist.Add(new BuildingFloorNo { FloorNo = 2 });
            alist.Add(new BuildingFloorNo { FloorNo = 3 });
            alist.Add(new BuildingFloorNo { FloorNo = 4 });
            my.ItemsSource = alist;

            // 户信息
            DataTable pic = new DataTable();
            pic.Columns.Add("FullPath");
            pic.Columns.Add("Tips");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "1");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "2");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "3");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "4");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "5");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "6");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "7");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "8");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "9");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "10");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "11");
            this.lstImgs.ItemsSource = pic.DefaultView;

            floorRoomsDict.Add(-1, pic);

            // 
            for (int i = 0; i < 5;i++ )
            {
                DataTable pic0 = new DataTable();
                pic0.Columns.Add("FullPath");
                pic0.Columns.Add("Tips");
                pic0.Rows.Add(i + @"层01室", "1");
                pic0.Rows.Add(i + @"层02室", "2");
                floorRoomsDict.Add(i, pic0);
                
                ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();
                int itemcount0 = 10;
                for (int j = 0; j < itemcount0; j++)
                {
                 customers0.Add(new Customer()
                 {
                    ID = j,
                    Name = i + @"层01室:"+"姓名item" + j.ToString(),
                    Age = 10 + j
                  });
                }

                RoomResidents.Add(i + @"层01室", customers0);
            }

            
           /////
            int itemcount = 107;
            for (int j = 0; j < itemcount; j++)
            {
                customers.Add(new Customer()
                {
                    ID = j,
                    Name = "姓名item" + j.ToString(),
                    Age = 10 + j
                });
            }

            // Calculate the total pages
            totalPage = itemcount / itemPerPage;
            if (itemcount % itemPerPage != 0)
            {
                totalPage += 1;
            }

            view.Source = customers;

            view.Filter += new FilterEventHandler(view_Filter);

            this.personlistView.DataContext = view;
            ShowCurrentPageIndex();
           // this.tbTotalPage.Text = totalPage.ToString();
        }

        private void Image_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button image = sender as Button;
            Border border = image.Parent as Border;
            border.BorderThickness = new Thickness(2, 2, 2, 2);
        }

        private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button image = sender as Button;
            Border border = image.Parent as Border;
            border.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button bton = sender as Button;
            string strid = bton.ToolTip as string;
            string roomName = bton.Content as string;
            if (strid != null && roomName !=null)
            {
                int index = Convert.ToInt32(strid);
                Console.WriteLine(index);
                ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();
                RoomResidents.TryGetValue(roomName, out customers0);

                view.Source = customers0;

                view.Filter += new FilterEventHandler(view_Filter);

                this.personlistView.DataContext = view;
                this.personlistView.ItemsSource = customers0;
            }

        }

        void view_Filter(object sender, FilterEventArgs e)
        {
            int index = customers.IndexOf((Customer)e.Item);

            if (index >= itemPerPage * currentPageIndex && index < itemPerPage * (currentPageIndex + 1))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            // Display the first page
            if (currentPageIndex != 0)
            {
                currentPageIndex = 0;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            // Display previous page
            if (currentPageIndex > 0)
            {
                currentPageIndex--;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            // Display next page
            if (currentPageIndex < totalPage - 1)
            {
                currentPageIndex++;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            // Display the last page
            if (currentPageIndex != totalPage - 1)
            {
                currentPageIndex = totalPage - 1;
                view.View.Refresh();
            }
            ShowCurrentPageIndex();
        }

        private void my_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox floorCombox = sender as ComboBox;
            if (null != floorCombox)
            {
                Console.WriteLine(floorCombox.SelectedIndex);
                BuildingFloorNo floorNo = floorCombox.SelectedItem as BuildingFloorNo;
                if (null != floorNo)
                {
                    Console.WriteLine(floorNo.FloorNo);
                
                  DataTable rooms = new DataTable();
                  if(floorRoomsDict.TryGetValue(floorNo.FloorNo, out rooms))
                  {
                    this.lstImgs.ItemsSource = rooms.DefaultView;
                  }
                }
            }
        }


        private void personlistView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object o = personlistView.SelectedItem;
            if (o == null)
                return;
            Customer customer = o as Customer;
            MessageBox.Show(customer.ID + customer.Name + customer.Age);

        }

    }

}
