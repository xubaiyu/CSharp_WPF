using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            play();
            Console.WriteLine("Myclass End");
            //Console.Read();
            Thread.Sleep(100000);
        }

        public static  async void play()
        {
            await DisplayValue();
            Console.WriteLine("play");
        }

        public static Task<double> GetvalueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    num1 = num1 / num2;

                }
                return num1;


            });
        }
        public static async Task DisplayValue()
        {
            double result = await GetvalueAsync(1234.5, 1.01);

            Console.WriteLine("Value is:" + result);

        }
    }
}
