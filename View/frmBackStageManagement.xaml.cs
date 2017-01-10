using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MYHQ_DBMS
{
    /// <summary>
    ///     frmTracksControl.xaml 的交互逻辑
    /// </summary>
    public partial class FrmBackStageManagement : Window
    {
        public FrmBackStageManagement()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //add BlackoutDates
            StartDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));
            EndDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));

            StartDate.SelectedDate = DateTime.Now.AddDays(-1).Date;
            StartDate.Text = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            EndDate.SelectedDate = DateTime.Now.Date;

            StartTime.SelectedTime = DateTime.Now;
            EndTime.SelectedTime = DateTime.Now;
        }

        #region 窗口标题栏

        /// <summary>
        ///     拖动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        /// <summary>
        ///     关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private int i;

        /// <summary>
        ///     标题栏双击事件
        /// </summary>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) =>
            {
                timer.IsEnabled = false;
                i = 0;
            };
            timer.IsEnabled = true;

            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                WindowState = WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
        }

        /// <summary>
        ///     窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        ///     窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal; //设置窗口还原
            else
                WindowState = WindowState.Maximized; //设置窗口最大化
        }

        #endregion
    }
}