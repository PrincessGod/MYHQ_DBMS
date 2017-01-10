using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MYHQ_DBMS
{
    /// <summary>
    ///     frmSingelTargetPlaybacks.xaml 的交互逻辑
    /// </summary>
    public partial class frmAddUser : Window
    {
        public frmAddUser()
        {
            InitializeComponent();
        }


        private void ButtonQuery_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //this.m_View.BackState();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PassWord.Password.ToCharArray().Length < 6)
            {
                Task.Factory.StartNew(() => { Thread.Sleep(500); })
                    .ContinueWith(t => { MainSnackbar.MessageQueue.Enqueue("您输入的密码少于6位!"); },
                        TaskScheduler.FromCurrentSynchronizationContext());

                return;
            }
            if (PassWord.Password != SurePs.Password)
                Task.Factory.StartNew(() => { Thread.Sleep(500); })
                    .ContinueWith(t => { MainSnackbar.MessageQueue.Enqueue("两次密码输入不一致!"); },
                        TaskScheduler.FromCurrentSynchronizationContext());
        }


        private void PassWord_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PassWord.Password.ToCharArray().Length < 6)
                Task.Factory.StartNew(() => { Thread.Sleep(500); })
                    .ContinueWith(t => { MainSnackbar.MessageQueue.Enqueue("您输入的密码少于6位!"); },
                        TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SurePS_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PassWord.Password != SurePs.Password)
                Task.Factory.StartNew(() => { Thread.Sleep(500); })
                    .ContinueWith(t => { MainSnackbar.MessageQueue.Enqueue("两次密码输入不一致!"); },
                        TaskScheduler.FromCurrentSynchronizationContext());
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