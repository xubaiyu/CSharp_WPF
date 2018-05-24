using BuildingFloor.Models;
using BuildingFloor.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BuildingFloor.ViewModels
{
    public class MyViewModel: ViewModelBase
    {
        /// <summary>
        /// 球机图层元素的实时数据
        /// </summary>
        private MyModel domyModelShow = null;
        public MyModel DomyModelShow
        {
            get { return domyModelShow; }
            set { Set(() => DomyModelShow, ref domyModelShow, value); }
        }
        public RelayCommand LoadedCommand { private set; get; }
        public RelayCommand<EventArgs> ClosedCommand { private set; get; }

        public RelayCommand<Button> MouseMoveCommand { private set; get; }

        public RelayCommand<Button> MouseLeaveCommand { private set; get; }
        public RelayCommand<Customer> MouseDoubleClickCommand { private set; get; }
        public RelayCommand<Button> ButtonClickCommand { private set; get; }
        public RelayCommand<ComboBox> SelectionChangedCommand { private set; get; }

        public RelayCommand<DataGridAutoGeneratingColumnEventArgs> AutoGeneratingColumnCommand { private set; get; }


        public MyViewModel()
        {   
            LoadedCommand = new RelayCommand(Loaded_CallBack);
            ClosedCommand = new RelayCommand<EventArgs>(Closed_CallBack);
            MouseMoveCommand = new RelayCommand<Button>(MouseMove_CallBack);
            MouseLeaveCommand = new RelayCommand<Button>(MouseLeave_CallBack);
            MouseDoubleClickCommand = new RelayCommand<Customer>(MouseDoubleClick_CallBack);
            ButtonClickCommand = new RelayCommand<Button>(ButtonClick_CallBack);
            SelectionChangedCommand = new RelayCommand<ComboBox>(SelectionChanged_CallBack);
            AutoGeneratingColumnCommand = new RelayCommand<DataGridAutoGeneratingColumnEventArgs>(AutoGeneratingColumn_CallBack);

            //alist.Add(new BuildingFloorNo { FloorNo = -1 });
            //alist.Add(new BuildingFloorNo { FloorNo = 1 });
            //alist.Add(new BuildingFloorNo { FloorNo = 2 });
            //alist.Add(new BuildingFloorNo { FloorNo = 3 });
            //alist.Add(new BuildingFloorNo { FloorNo = 4 });
        }

        private void AutoGeneratingColumn_CallBack(DataGridAutoGeneratingColumnEventArgs e)
        {
            var displayName = GetPropertyDisplayName(e.PropertyDescriptor);

            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
        }

        public static string GetPropertyDisplayName(object descriptor)
        {
            var pd = descriptor as PropertyDescriptor;

            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                var displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;

                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                var pi = descriptor as PropertyInfo;

                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        var displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }

            return null;
        }
        private void MouseDoubleClick_CallBack(Customer customer)
        {
            //MessageBox.Show(customer.ID + customer.Name + customer.Age);

            
            if(customer != null)
            {
              ResidentInfoWnd residentWnd = new ResidentInfoWnd();
              ResidentModel.Instance.NotifyGetCustomer(new ObservableCollection<Customer>() { customer });
              residentWnd.ShowDialog();
            }
            
            
        }

        private void SelectionChanged_CallBack(ComboBox sender)
        {
            ComboBox floorCombox = sender as ComboBox;
            if (null != floorCombox)
            {
                Console.WriteLine(floorCombox.SelectedIndex);
                BuildingFloorNo floorNo = floorCombox.SelectedItem as BuildingFloorNo;
                if (null != floorNo)
                {
                    Console.WriteLine(floorNo.FloorNo);

                    DataTable roomsOfFloor = new DataTable();

                    if (MyModel.Instance.floorRoomsDict.TryGetValue(floorNo.FloorNo, out roomsOfFloor))
                    {
                        rooms.Clear();
                        //Rooms = roomsOfFloor.Clone();
                        //Rooms = roomsOfFloor;
                        rooms.Merge(roomsOfFloor);
                        Customers.Clear();
                        return;
                        
                        //this.lstImgs.ItemsSource = rooms.DefaultView;
                        //this.lstImgs.DataContext = Rooms.DefaultView;
                    }
                }
            }
            // clear personlistView
            ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();

            //this.personlistView.DataContext = customers0;
            //this.personlistView.ItemsSource = customers0;
        }

      

        private void ButtonClick_CallBack(Button sender)
        {
            Button bton = sender as Button;
            string strid = bton.ToolTip as string;
            string roomName = bton.Content as string;
            if (strid != null && roomName != null)
            {
                long index = Convert.ToInt64(strid);
                Console.WriteLine(index);
                ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();
                MyModel.Instance.RoomResidents.TryGetValue(roomName, out customers0);
                Customers.Clear();
                if (customers0 != null)
                {
                    foreach (Customer o in customers0)
                    {
                        Customers.Add(o);
                    }
                }
                

                //view.Source = customers;

                //view.Filter += new FilterEventHandler(view_Filter);

                //this.personlistView.DataContext = Customers;
                //Console.WriteLine("BBB-" + this.personlistView.DataContext.ToString());
                //this.personlistView.ItemsSource = customers;
            }
        }

        private void MouseLeave_CallBack(Button sender)
        {
            Button image = sender as Button;
            Border border = image.Parent as Border;
            border.BorderThickness = new Thickness(0, 0, 0, 0);
        }

        private void MouseMove_CallBack(Button sender)
        {
            Button image = sender as Button;
            Border border = image.Parent as Border;
            border.BorderThickness = new Thickness(2, 2, 2, 2);

            Button bton = sender as Button;
            string strid = bton.ToolTip as string;
            string roomName = bton.Content as string;
            if (strid != null && roomName != null)
            {
                //bton.ToolTip = "9999999";
                Tips = MyModel.Instance.Tips;
            }
        }




        private void Closed_CallBack(EventArgs e)
        {
            //throw new NotImplementedException();
            MyModel.Instance.UpateFloorsInfoEvent -= UpdateFloorsInfo_CallBack; 
        }

        private void Loaded_CallBack()
        {
            //if (DomyModelShow == null)
            //{
            //    DomyModelShow = new MyModel();
            //}
            MyModel.Instance.UpateFloorsInfoEvent += UpdateFloorsInfo_CallBack; 
            MyModel.Instance.NotifyGetFloor();
        }

        private void UpdateFloorsInfo_CallBack(ObservableCollection<BuildingFloorNo> obj)
        {
            AList = obj;
            //AList.Clear();
            ////AList = obj;
            //foreach (BuildingFloorNo no in obj)
            //{
            //    AList.Add(no);

            //}
 
        }
         // 楼层
        private ObservableCollection<BuildingFloorNo> alist = null;
        public ObservableCollection<BuildingFloorNo> AList
        {
            get { return alist; }
            set { Set(() => AList, ref alist, value); }
        }
        // 楼层-户
        Dictionary<int, DataTable> floorRoomsDict = new Dictionary<int, DataTable>();
        // 户-居民
        Dictionary<string, ObservableCollection<Customer>> RoomResidents = new Dictionary<string, ObservableCollection<Customer>>();
       
        CollectionViewSource view = new CollectionViewSource();
        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }
       

        DataTable rooms = new DataTable();
        public DataView Rooms
        {
            get { return rooms.DefaultView; }
            //set { rooms = value; }

        }

        private string tips = string.Empty;
        public string Tips
        {
            get { return tips; }
            set { Set(() => Tips, ref tips, value); }
        }
      
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    alist.Add(new BuildingFloorNo { FloorNo = -1 });
        //    alist.Add(new BuildingFloorNo { FloorNo = 1 });
        //    alist.Add(new BuildingFloorNo { FloorNo = 2 });
        //    alist.Add(new BuildingFloorNo { FloorNo = 3 });
        //    alist.Add(new BuildingFloorNo { FloorNo = 4 });
        //    my.DataContext = this;
        //    Console.WriteLine("AAA"+my.DataContext.ToString());
        //   // my.ItemsSource = alist;

        //    // 户信息
        //    //DataTable pic = new DataTable();
        //    //pic.Columns.Add("FullPath");
        //    //pic.Columns.Add("Tips");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "1");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "2");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "3");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "4");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "5");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "6");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "7");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "8");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "9");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "10");
        //    //pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png", "11");
        //    //this.lstImgs.ItemsSource = pic.DefaultView;

        //    //floorRoomsDict.Add(-1, pic);

        //    // 
        //    for (int i = -1; i < 5; i++)
        //    {
        //        DataTable pic0 = new DataTable();
        //        pic0.Columns.Add("FullPath");
        //        pic0.Columns.Add("Tips");
        //        pic0.Rows.Add(i + @"层01室", "1");
        //        pic0.Rows.Add(i + @"层02室", "2");
        //        floorRoomsDict.Add(i, pic0);

        //        ObservableCollection<Customer> customers0 = new ObservableCollection<Customer>();
        //        int itemcount0 = 10;
        //        for (int j = 0; j < itemcount0; j++)
        //        {
        //            customers0.Add(new Customer()
        //            {
        //                ID = j,
        //                Name = i + @"层01室:" + "姓名item" + j.ToString(),
        //                Age = 10 + j
        //            });
        //        }

        //        RoomResidents.Add(i + @"层01室", customers0);
        //    }

            
           

            
        //   /////
        //    //int itemcount = 107;
        //    //for (int j = 0; j < itemcount; j++)
        //    //{
        //    //    customers.Add(new Customer()
        //    //    {
        //    //        ID = j,
        //    //        Name = "姓名item" + j.ToString(),
        //    //        Age = 10 + j
        //    //    });
        //    //}

        //    //// Calculate the total pages
        //    //totalPage = itemcount / itemPerPage;
        //    //if (itemcount % itemPerPage != 0)
        //    //{
        //    //    totalPage += 1;
        //    //}

        //    //view.Source = customers;

        //    //view.Filter += new FilterEventHandler(view_Filter);

        //    //this.personlistView.DataContext = view;
        //    //ShowCurrentPageIndex();
        //   // this.tbTotalPage.Text = totalPage.ToString();

        //}

        //private void Image_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    Button image = sender as Button;
        //    Border border = image.Parent as Border;
        //    border.BorderThickness = new Thickness(2, 2, 2, 2);
        //}

        //private void Image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    Button image = sender as Button;
        //    Border border = image.Parent as Border;
        //    border.BorderThickness = new Thickness(0, 0, 0, 0);
        //}

      

       

    

     


    
  


       

    }

}
