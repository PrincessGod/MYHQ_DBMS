using MYHQ_DBMS.Command;
using MYHQ_DBMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MYHQ_DBMS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private LoginInfo loginInfo;

        public LoginViewModel()
        {
            loginInfo = new LoginInfo();
            loginInfo.PassWord = "123123";
            loginInfo.UserName = "PrincessGod";
        }
        #region Property
        public string UserName
        {
            get
            {
                return loginInfo.UserName;
            }
            set 
            {
                if (loginInfo.UserName.Equals(value)) return;
                loginInfo.UserName = value;
            }
        }

        public string PassWord
        {
            get
            {
                return loginInfo.PassWord;
            }
            set
            {
                if (loginInfo.PassWord.Equals(value)) return;
                loginInfo.PassWord = value;
            }
        }

        private string errorMessage = "";

        public string ErrorMessage
        {
            get { return errorMessage; }
            set 
            {
                if (errorMessage.Equals(value)) return;
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
                Task.Delay(TimeSpan.FromSeconds(10))
                .ContinueWith((t, _) => ErrorMessage = "", null,
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        #endregion

        #region Command
        public ICommand RunLoginCommand
        {
            get
            {
                return new AnotherCommandImplementation(ExecuteRunLogin);
            }
        }

        /// <summary>
        /// 登陆入口 获取用户名密码执行之后操作
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteRunLogin(object obj)
        {
            if ((this.loginInfo.UserName != "PrincessGod" && this.loginInfo.PassWord != "123123"))
            { 
                this.ErrorMessage = "用户名不存在或密码错误";
                return;
            }

            var view = new frmBackStageManagement
            {
                DataContext = new MainWindowViewModel()
            };
            
            view.Show();

            ((Window)obj).Close();

        }
        #endregion
    }
}
