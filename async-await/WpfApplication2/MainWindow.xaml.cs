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

namespace WpfApplication2
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
            Console.WriteLine("button click 1");
            B();
            //await A();
            Console.WriteLine("button click 2");
        }

        private async void B()
        {
            Console.WriteLine("button click 3");
            double val = await A();
            C();
            Console.WriteLine("button click 4 "+val);
            //Console.WriteLine("button click 4 ");
            //C();
        }

        private async  Task<double> A()
        {
            Console.WriteLine("button click 5");
            double k = 2;
           
            Console.WriteLine("button click 6");
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {

                    k = k + 3;

                }
            });
            Console.WriteLine("button click 7");
            return k;
        }

        private async void C()
        {
            double k = 2;
            Console.WriteLine("button click C -1");
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {

                    k = k * 3;

                }
            });
            Console.WriteLine("button click C-2");
        }
    }
}
