using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MYHQ_DBMS.Command;
using MYHQ_DBMS.Model;

// ReSharper disable All

namespace MYHQ_DBMS.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly LoginInfo _loginInfo = new LoginInfo();
        private Random random = new Random();

        #region Property

        public string UserName
        {
            get { return _loginInfo.UserName; }
            set
            {
                if (value.Equals(_loginInfo.UserName)) return;
                _loginInfo.UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string PassWord
        {
            get { return _loginInfo.PassWord; }
            set
            {
                if (value.Equals(_loginInfo.PassWord)) return;
                _loginInfo.PassWord = value;
            }
        }

        private string _errorMessage = "";

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (_errorMessage == value) return;
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
                Task.Delay(TimeSpan.FromSeconds(5))
                    .ContinueWith((t, _) => ErrorMessage = "", null,
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        #endregion

        #region Command

        public ICommand RunLoginCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunLogin); }
        }

        /// <summary>
        ///     登陆入口 获取用户名密码执行之后操作
        /// </summary>
        /// <param name="obj"></param>
        private async void ExecuteRunLogin(object obj)
        {
            if (!TestInput()) return;

            //Whiting dialog
            var view = new WitingDialog()
            {
                ButtonCancle = {Visibility = Visibility.Collapsed}
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogOpeningEventHandler);


            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));

            if (result != null && (bool) result)
                LoginSuccess(obj);
        }

        private async void AddMemberDialogOpeningEventHandler(object sender, DialogOpenedEventArgs eventArgs)
        {
            var init = false;

            await Task.Delay(TimeSpan.FromSeconds(random.Next(5)))
                .ContinueWith((t, o) => { init = random.NextDouble() < .5; }, null,
                    TaskScheduler.FromCurrentSynchronizationContext());

            eventArgs.Session.UpdateContent(new SimpleMessageDialog
            {
                OkButton = {CommandParameter = init},
                OkButtonText = {Text = init ? "I always knew it,\r\nshow me some f***ing fun!!" : "WTF!!!"},
                CancelButton = {Visibility = Visibility.Collapsed},
                Message = {Text = init ? "You are a lucky kid!" : "Maybe you should try again."},
                Icon = {Kind = PackIconKind.EmoticonDevil},
            });
        }

        private static void LoginSuccess(object obj)
        {
            var view = new FrmBackStageManagement
            {
                DataContext = new MainWindowViewModel()
            };

            view.Show();

            ((Window) obj).Close();
        }

        private bool TestInput()
        {
            if (string.IsNullOrEmpty(_loginInfo.UserName))
            {
                ErrorMessage = "Text the UserName , PLZ :)";
                return false;
            }
            else if (string.IsNullOrEmpty(_loginInfo.PassWord))
            {
                ErrorMessage = "Text the Password , PLZ :)";
                return false;
            }
            return true;
        }

        #endregion
    }
}