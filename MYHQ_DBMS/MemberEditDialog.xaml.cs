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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MYHQ_DBMS
{
    /// <summary>
    /// MemberEditDialog.xaml 的交互逻辑
    /// </summary>
    public partial class MemberEditDialog : UserControl
    {
        public MemberEditDialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Name.Text))
            {
                Message("请输入姓名!");
                return;
            }
            if (string.IsNullOrEmpty(this.Department.Text))
            {
                Message("请输入部门!");
                return;
            }
            if (string.IsNullOrEmpty(this.Duty.Text))
            {
                Message("请输入职务!");
                return;
            }
            if (string.IsNullOrEmpty(this.UserName.Text))
            {
                Message("请输入用户名!");
                return;
            }
            if (this.PassWord.Password.ToCharArray().Length < 6)
            {
                Message("您输入的密码少于6位!");
                return;
            }
            if (this.PassWord.Password != this.SurePs.Password)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("两次密码输入不一致!");
                }, TaskScheduler.FromCurrentSynchronizationContext());
                butok.CommandParameter = "Do not close";
                return;
            }
            butok.CommandParameter = true;
        }

        private void Message(string msg)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
            }).ContinueWith(t =>
            {
                MainSnackbar.MessageQueue.Enqueue(msg);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            butok.CommandParameter = "Do not close";
        }


        private void PassWord_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.PassWord.Password.ToCharArray().Length < 6)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("您输入的密码少于6位!");
                }, TaskScheduler.FromCurrentSynchronizationContext());

                return;
            }
        }

        private void SurePS_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.PassWord.Password != this.SurePs.Password)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(500);
                }).ContinueWith(t =>
                {
                    MainSnackbar.MessageQueue.Enqueue("两次密码输入不一致!");
                }, TaskScheduler.FromCurrentSynchronizationContext());

                return;
            }
        }

        private void textBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!isNumberic(text))
                { e.CancelCommand(); }
            }
            else { e.CancelCommand(); }
        }

        private void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!isNumberic(e.Text))
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        //isDigit是否是数字
        public static bool isNumberic(string _string)
        {
            if (string.IsNullOrEmpty(_string))
                return false;
            foreach (char c in _string)
            {
                if (!(char.IsDigit(c) || char.IsLetter(c)))
                    //if(c<'0' c="">'9')//最好的方法,在下面测试数据中再加一个0，然后这种方法效率会搞10毫秒左右
                    return false;
            }
            return true;
        }


    }
    
}
