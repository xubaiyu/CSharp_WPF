using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace wordToNumber
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string strWord = "第十二单元";
            Console.WriteLine( WordToNumber(strWord) );
        }

        public static string WordToNumber(string word)
        {
            string e = "([零一二三四五六七八九十百千万亿])+";
            MatchCollection mc = Regex.Matches(word, e);
            foreach (Match m in mc)
            {
                word = word.Replace(m.Value, Word2Number(m.Value));
            }
            return word;
        }
        private static string Word2Number(string w)
        {
            if (w == "")
                return w;

            string e = "零一二三四五六七八九";
            string[] ew = new string[] { "十", "百", "千" };
            string ewJoin = "十百千";
            string[] ej = new string[] { "万", "亿" };
            string rss = "^([" + e + ewJoin + "]+" + ej[1] + ")?([" + e
                + ewJoin + "]+" + ej[0] + ")?([" + e + ewJoin + "]+)?";
            string[] mcollect = Regex.Split(w, rss);

            return (
                Convert.ToInt64(foh(mcollect[1]))
                //Convert.ToInt64(foh(mcollect[2])) * 10000
                //Convert.ToInt64(foh(mcollect[3]))
                ).ToString();
        }

        private static int foh(string str)
        {
            string e = "零一二三四五六七八九";
            string[] ew = new string[] { "十", "百", "千" };
            string[] ej = new string[] { "万", "亿" };

            int a = 0;
            if (str.IndexOf(ew[0]) == 0)
                a = 10;
            str = Regex.Replace(str, e[0].ToString(), "");

            if (Regex.IsMatch(str, "([" + e + "])$"))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])$").Value[0]);
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[0]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[0]).Value[0]) * 10;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[1]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[1]).Value[0]) * 100;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[2]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[2]).Value[0]) * 1000;
            }
            return a;
        }

    }
}
