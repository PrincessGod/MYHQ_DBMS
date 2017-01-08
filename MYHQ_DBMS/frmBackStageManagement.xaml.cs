
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace MYHQ_DBMS
{
    /// <summary>
    /// frmTracksControl.xaml 的交互逻辑
    /// </summary>
    public partial class frmBackStageManagement : Window
    {
        public frmBackStageManagement()
        {
            InitializeComponent();
        }

        #region 窗口标题栏
        /// <summary>
        /// 拖动窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        int i = 0;
        /// <summary>
        /// 标题栏双击事件
        /// </summary>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;

            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                this.WindowState = this.WindowState == WindowState.Maximized ?
                              WindowState.Normal : WindowState.Maximized;
            }
        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        /// 窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        #endregion
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

        }
        List<Test1> t1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            t1 = new List<Test1>() 
            {
                new Test1(){ V1 = "张三", V2 = DateTime.Now.ToString(), V3 = "删除了一个表格"},
                new Test1(){ V1 = "张三", V2 = DateTime.Now.ToString(), V3 = "删除了一个表格"},
                new Test1(){ V1 = "张三", V2 = DateTime.Now.ToString(), V3 = "删除了一个表格"},
                new Test1(){ V1 = "张三", V2 = DateTime.Now.ToString(), V3 = "删除了一个表格"}
            };

            List<Test2> t2 = new List<Test2>() 
            {
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
                new Test2(){ V1 = "张三", V2 = "水电部", V3 = "科员", V4 = "Ripple", V5 = "12asd12444", V6 = "一级"},
            };

            List<Test3> t3 = new List<Test3>() 
            {
                new Test3(){ V1 = "数据库一"},
                new Test3(){ V1 = "数据库一"},
                new Test3(){ V1 = "数据库一"},
            };


            this.UserManagement.ItemsSource = t2;
            this.DataBaseManagement.ItemsSource = t3;

            //add BlackoutDates
            StartDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));
            EndDate.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), new DateTime(2100, 1, 1)));

            StartDate.SelectedDate = DateTime.Now.AddDays(-1).Date;
            StartDate.Text = DateTime.Now.AddDays(-1).Date.ToShortDateString();
            EndDate.SelectedDate = DateTime.Now.Date;

            StartTime.SelectedTime = DateTime.Now;
            EndTime.SelectedTime = DateTime.Now;

            this.DataContext = new DialogsViewModel();
        }
        private void BTSelect_Click(object sender, EventArgs e)
        {
          //  this.m_View.ActiveTaskInOwner();
        }
        private void BtOK_Click(object sender, EventArgs e)
        {
            //if(this.PiHao.Text!=null&&this.CBTracksRange.SelectedValue!=null)
            //{
            //    this.TracksControlPiHao = this.PiHao.Text;
            //    this.TracksControlRange = this.CBTracksRange.Text;
            //    this.Close();
            //    MessageBox.Show(this.TracksControlPiHao, this.TracksControlRange);
            //}
            //else
            //{
            //    MessageBox.Show("您没有选择目标或者范围！");
            //    return;
            //}   
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this.m_View.BackState();
        }

        private void BTAddUser_Click(object sender, RoutedEventArgs e)
        {
            frmAddUser frm = new frmAddUser();
            frm.Owner = this;
            frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            frm.ShowDialog();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartTime.SelectedTime != null && EndTime.SelectedTime != null && StartDate.SelectedDate != null && EndDate.SelectedDate != null)
            {
                if (StartDate.SelectedDate <= EndDate.SelectedDate)
                {
                    if (StartDate.SelectedDate == EndDate.SelectedDate && StartTime.SelectedTime > EndTime.SelectedTime)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            Thread.Sleep(500);
                        }).ContinueWith(t =>
                        {
                            MainSnackbar.MessageQueue.Enqueue("开始时间不能晚于结束时间!");
                        }, TaskScheduler.FromCurrentSynchronizationContext());

                        return;
                    }

                    ///do some thing
                    var view = new WitingDialog
                    {
                    };

                    //show the dialog
                    var result = await DialogHost.Show(view, "RootDialog", Search_DialogHost_OnDialogOpening, Search_DialogHost_OnDialogClosing);

                    //check the result...
                    Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
                }
                else
                {
                    Task.Factory.StartNew(() =>
                    {
                        Thread.Sleep(500);
                    }).ContinueWith(t =>
                    {
                        MainSnackbar.MessageQueue.Enqueue("开始时间不能晚于结束时间!");
                    }, TaskScheduler.FromCurrentSynchronizationContext());

                    return;
                }

            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("请先输入时间范围");
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        #region Dialog event
        private void Search_DialogHost_OnDialogOpening(object sender, DialogOpenedEventArgs eventArgs)
        {
            this.DutyManagement.ItemsSource = null;
            //lets run a fake operation for 3 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
             
        }
        private void Search_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            this.DutyManagement.ItemsSource = t1;
            Console.WriteLine("Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Test1
    {
        public string V1 { get; set; }

        public string V2 { get; set; }

        public string V3 { get; set; }
    }

    public class Test2
    {
        public string V1 { get; set; }

        public string V2 { get; set; }

        public string V3 { get; set; }


        public string V4 { get; set; }

        public string V5 { get; set; }

        public string V6 { get; set; }
    }

    public class Test3
    {
        public string V1 { get; set; }
    }
}