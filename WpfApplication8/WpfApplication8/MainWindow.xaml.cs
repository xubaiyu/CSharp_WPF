using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication8
{
    /// <summary>
    /// showpifu.xaml 的交互逻辑
    /// </summary>
    public partial class showpifu : Window
    {
        public showpifu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DataTable pic = new DataTable();
            pic.Columns.Add("FullPath");
            pic.Columns.Add("Tips");
            pic.Rows.Add(@"D:\GA\GACU_WPF\branches\GaNet20180417\Client\Resources\Gray\Images\ico_ballcamra_pressed.png","1");
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
            string strid =  bton.ToolTip as string;
            if(strid != null)
            {
                int index = Convert.ToInt32(strid);
                Console.WriteLine(index);
                
            }

        }

    }


}