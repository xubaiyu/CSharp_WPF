using Microsoft.Windows.Shell;
using System;
using System.Collections.Generic;
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

namespace ACMEControl.Controls
{
    /// <summary>
    /// 通用窗口风格
    /// </summary>
    public class BaseWnd : Window
    {
        static BaseWnd()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWnd), new FrameworkPropertyMetadata(typeof(BaseWnd)));
        }

        /// <summary>
        /// 非客户区颜色
        /// </summary>
        public Brush NoClientBackground
        {
            get { return (Brush)GetValue(NoClientBackgroundProperty); }
            set { SetValue(NoClientBackgroundProperty, value); }
        }

        public static readonly DependencyProperty NoClientBackgroundProperty =
            DependencyProperty.Register("NoClientBackground", typeof(Brush), typeof(BaseWnd), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// 标题栏内容
        /// </summary>
        public object CaptionContent
        {
            get { return (object)GetValue(CaptionContentProperty); }
            set { SetValue(CaptionContentProperty, value); }
        }

        public static readonly DependencyProperty CaptionContentProperty =
            DependencyProperty.Register("CaptionContent", typeof(object), typeof(BaseWnd), new PropertyMetadata(null));

        /// <summary>
        /// 标题颜色
        /// </summary>
        public Brush TitleBrush
        {
            get { return (Brush)GetValue(TitleBrushProperty); }
            set { SetValue(TitleBrushProperty, value); }
        }

        public static readonly DependencyProperty TitleBrushProperty =
            DependencyProperty.Register("TitleBrush", typeof(Brush), typeof(BaseWnd), new PropertyMetadata(Brushes.White));

        /// <summary>
        /// 标题栏高度
        /// </summary>
        public double CaptionHeight
        {
            get { return (double)GetValue(CaptionHeightProperty); }
            set { SetValue(CaptionHeightProperty, value); }
        }

        public static readonly DependencyProperty CaptionHeightProperty =
            DependencyProperty.Register("CaptionHeight", typeof(double), typeof(BaseWnd), new PropertyMetadata(30.0));

        /// <summary>
        /// 最小化按钮的显示状态
        /// </summary>
        public Visibility MinBtnVisibility
        {
            get { return (Visibility)GetValue(MinBtnVisibilityProperty); }
            set { SetValue(MinBtnVisibilityProperty, value); }
        }

        public static readonly DependencyProperty MinBtnVisibilityProperty =
            DependencyProperty.Register("MinBtnVisibility", typeof(Visibility), typeof(BaseWnd), new PropertyMetadata(Visibility.Visible));

        /// <summary>
        /// 最小化按钮的tooltip
        /// </summary>
        public string MinBtnTooltip
        {
            get { return (string)GetValue(MinBtnTooltipProperty); }
            set { SetValue(MinBtnTooltipProperty, value); }
        }

        public static readonly DependencyProperty MinBtnTooltipProperty =
            DependencyProperty.Register("MinBtnTooltip", typeof(string), typeof(BaseWnd), new PropertyMetadata(null));

        /// <summary>
        /// 最大化按钮的tooltip
        /// </summary>
        public string MaxBtnTooltip
        {
            get { return (string)GetValue(MaxBtnTooltipProperty); }
            set { SetValue(MaxBtnTooltipProperty, value); }
        }

        public static readonly DependencyProperty MaxBtnTooltipProperty =
            DependencyProperty.Register("MaxBtnTooltip", typeof(string), typeof(BaseWnd), new PropertyMetadata(null));

        /// <summary>
        /// 关闭按钮的tooltip
        /// </summary>
        public string CloseBtnTooltip
        {
            get { return (string)GetValue(CloseBtnTooltipProperty); }
            set { SetValue(CloseBtnTooltipProperty, value); }
        }

        public static readonly DependencyProperty CloseBtnTooltipProperty =
            DependencyProperty.Register("CloseBtnTooltip", typeof(string), typeof(BaseWnd), new PropertyMetadata(null));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button minBtn = GetTemplateChild("PART_MINBTN") as Button;
            Button maxBtn = GetTemplateChild("PART_MAXBTN") as Button;
            Button closeBtn = GetTemplateChild("PART_CLOSEBTN") as Button;

            if (minBtn != null)
            {
                minBtn.Click += minBtn_Click;
            }

            if (maxBtn != null)
            {
                maxBtn.Click += maxBtn_Click;
            }

            if (closeBtn != null)
            {
                closeBtn.Click += closeBtn_Click;
            }
        }

        /// <summary>
        /// 关闭按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(Window.GetWindow(this));
        }

        /// <summary>
        /// 最大化按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void maxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Maximized)
            {
                SystemCommands.RestoreWindow(Window.GetWindow(this));
            }
            else
            {
                SystemCommands.MaximizeWindow(Window.GetWindow(this));
            }
        }

        /// <summary>
        /// 最小化按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void minBtn_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(Window.GetWindow(this));
        }
    }
}
