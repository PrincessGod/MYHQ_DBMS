using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MYHQ_DBMS.Command;
using MYHQ_DBMS.Model;

namespace MYHQ_DBMS.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            usersInfo = new ObservableCollection<UserInfo>
            {
                new UserInfo
                {
                    Name = "张三",
                    Department = "水电部",
                    Post = "科员",
                    UserName = "ZhangSan",
                    Passward = "1234567",
                    Permission = "仅浏览"
                },
                new UserInfo
                {
                    Name = "李四",
                    Department = "后勤",
                    Post = "科员",
                    UserName = "ZHAOsi",
                    Passward = "1234567",
                    Permission = "仅浏览"
                },
                new UserInfo
                {
                    Name = "王五",
                    Department = "办公中心",
                    Post = "厅长",
                    UserName = "WangWU",
                    Passward = "123434",
                    Permission = "全操作"
                },
                new UserInfo
                {
                    Name = "赵六",
                    Department = "人事",
                    Post = "副处长",
                    UserName = "zhAOliu",
                    Passward = "31233232332",
                    Permission = "全操作"
                }
            };
            operationsHistory = new ObservableCollection<OperationHistory>();
            databasesInfo = new ObservableCollection<DatabaseInfo>
            {
                new DatabaseInfo {Name = "数据库北京"},
                new DatabaseInfo {Name = "数据库武汉"},
                new DatabaseInfo {Name = "数据库上海"},
                new DatabaseInfo {Name = "数据库深圳"},
                new DatabaseInfo {Name = "数据库广州"}
            };
        }

        #region Property

        private ObservableCollection<UserInfo> usersInfo;

        public ObservableCollection<UserInfo> UsersInfo
        {
            get { return usersInfo; }
            set
            {
                if (usersInfo != null && usersInfo.Equals(value)) return;
                usersInfo = value;
                OnPropertyChanged("UsersInfo");
            }
        }

        private ObservableCollection<OperationHistory> operationsHistory;

        public ObservableCollection<OperationHistory> OperationsHistory
        {
            get { return operationsHistory; }
            set
            {
                if (operationsHistory != null && operationsHistory.Equals(value)) return;
                operationsHistory = value;
                OnPropertyChanged("OperationsHistory");
            }
        }

        private ObservableCollection<DatabaseInfo> databasesInfo;

        public ObservableCollection<DatabaseInfo> DatabasesInfo
        {
            get { return databasesInfo; }
            set
            {
                if (databasesInfo != null && databasesInfo.Equals(value)) return;
                databasesInfo = value;
                OnPropertyChanged("DatabasesInfo");
            }
        }

        private DateTime startTimeDate;

        public DateTime StartTimeDate
        {
            set
            {
                if (startTimeDate != null && startTimeDate == value) return;
                startTimeDate = value;
            }
        }

        private DateTime startTimeTime;

        public DateTime StartTimeTime
        {
            set
            {
                if (startTimeTime != null && startTimeTime == value) return;
                startTimeTime = value;
            }
        }

        private DateTime endTimeTime;

        public DateTime EndTimeTime
        {
            set
            {
                if (endTimeTime != null && endTimeTime == value) return;
                endTimeTime = value;
            }
        }

        private DateTime endTimeDate;

        public DateTime EndTimeDate
        {
            set
            {
                if (endTimeDate != null && endTimeDate == value) return;
                endTimeDate = value;
            }
        }

        #endregion

        #region Command

        public ICommand RunAddMemberDialogCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunAddMemberDialog); }
        }

        public ICommand RunDeleteMemberDialogCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunDeleteMemberDialog); }
        }

        public ICommand RunEditMemberDialogCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunEditMemberDialog); }
        }

        public ICommand RunSearchCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunSearch); }
        }

        public ICommand RunDatabaseBackupCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunDatabaseBackup); }
        }

        public ICommand RunDatabaseReviewCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunDatabaseReview); }
        }

        public ICommand RunExportOperationTableCommand
        {
            get { return new AnotherCommandImplementation(ExecuteRunExportOperationTable); }
        }

        /// <summary>
        ///     Add user function
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunAddMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new MemberEditDialog
            {
                DataContext = new UserInfo()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Delete user func
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunDeleteMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SimpleMessageDialog
            {
                Message =
                {
                    Text = string.Format("你确定要删除\r\n 用户名：{0}  账户：{1} ?", ((UserInfo) o).Name, ((UserInfo) o).UserName),
                    TextAlignment = TextAlignment.Center
                }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", DeleteMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Edit user informition
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunEditMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new MemberEditDialog
            {
                DataContext = (UserInfo) o,
                Title = {Text = "修改用户"},
                PassW = {Text = "新密码"}
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Back up database
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunDatabaseBackup(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SimpleMessageDialog
            {
                Message =
                {
                    Text = "数据库备份?\r\n" + ((DatabaseInfo) o).Name,
                    TextAlignment = TextAlignment.Center
                }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Restore database
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunDatabaseReview(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SimpleMessageDialog
            {
                Message =
                {
                    Text = "数据库恢复?\r\n" + ((DatabaseInfo) o).Name,
                    TextAlignment = TextAlignment.Center
                }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Export operation history table
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunExportOperationTable(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SimpleMessageDialog
            {
                Message =
                {
                    Text = "导出数据表?\r\n共 " + ((DataGrid) o).Items.Count + " 行",
                    TextAlignment = TextAlignment.Center
                }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        /// <summary>
        ///     Search operation history
        /// </summary>
        /// <param name="o"></param>
        private async void ExecuteRunSearch(object o)
        {
            if (startTimeTime != null && endTimeTime != null && startTimeDate != null && endTimeDate != null)
                if (startTimeDate <= endTimeDate)
                    if (!(startTimeDate == endTimeDate && startTimeTime > endTimeTime))
                    {
                        ///do some thing
                        var view = new WitingDialog();

                        //show the dialog
                        var result = await DialogHost.Show(view, "RootDialog", Search_DialogHost_OnDialogOpening,
                            Search_DialogHost_OnDialogClosing);

                        //check the result...
                        Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " +
                                          (result ?? "NULL"));
                        return;
                    }

            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view1 = new SimpleMessageDialog
            {
                Message =
                {
                    Text = "开始时间不能晚于结束时间!",
                    TextAlignment = TextAlignment.Center
                },
                CancelButton =
                {
                    Visibility = Visibility.Collapsed
                }
            };

            //show the dialog
            var result1 = await DialogHost.Show(view1, "RootDialog");


            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result1 ?? "NULL"));
        }

        #region Dialog event

        private void DeleteMemberDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");

            if (eventArgs.Parameter is bool && (bool) eventArgs.Parameter == false) return;

            //Something wrong , cancle closing...
            eventArgs.Cancel();
            //witing...
            eventArgs.Session.UpdateContent(new WitingDialog());
        }

        private void AddMemberDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");

            if (eventArgs.Parameter is bool && (bool) eventArgs.Parameter == false) return;

            //Something wrong , cancle closing...
            eventArgs.Cancel();

            //have to update the "session" with some new content!
            if (eventArgs.Parameter is UserControl)
            {
                var view = (MemberEditDialog) eventArgs.Parameter;
                if (view.DataContext != null && view.DataContext is UserInfo)
                {
                    var data = (UserInfo) view.DataContext;
                    if (string.IsNullOrEmpty(data.Name))
                    {
                        view.Message("请输入姓名!");
                        return;
                    }
                    if (string.IsNullOrEmpty(data.Department))
                    {
                        view.Message("请输入部门!");
                        return;
                    }
                    if (string.IsNullOrEmpty(data.Post))
                    {
                        view.Message("请输入职务!");
                        return;
                    }
                    if (string.IsNullOrEmpty(data.UserName))
                    {
                        view.Message("请输入用户名!");
                        return;
                    }
                    if (view.PassWord.Password.ToCharArray().Length < 6)
                    {
                        view.Message("您输入的密码少于6位!");
                        return;
                    }
                    if (view.PassWord.Password != view.SurePs.Password)
                    {
                        view.Message("两次密码输入不一致!");
                        return;
                    }
                    if (string.IsNullOrEmpty(data.Permission))
                    {
                        view.Message("请选择用户权限!");
                        return;
                    }

                    //do some thing
                    if (view.Title.Text == "添加用户")
                        ;

                    else if (view.Title.Text == "修改用户")
                        ;

                    //witing...
                    eventArgs.Session.UpdateContent(new WitingDialog());
                }
            }
        }

        private void Search_DialogHost_OnDialogOpening(object sender, DialogOpenedEventArgs eventArgs)
        {
            OperationsHistory = null;
            //lets run a fake operation for 3 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void Search_DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            OperationsHistory = new ObservableCollection<OperationHistory>
            {
                new OperationHistory {Name = "张三", Operation = "删除了一批数据", OperationTime = DateTime.Now.ToString()},
                new OperationHistory {Name = "李四", Operation = "增加了一批数据", OperationTime = DateTime.Now.ToString()},
                new OperationHistory {Name = "王五", Operation = "添加和删除数据", OperationTime = DateTime.Now.ToString()},
                new OperationHistory {Name = "张三", Operation = "更新了数据", OperationTime = DateTime.Now.ToString()}
            };
            Console.WriteLine("Closing dialog with parameter: " + (eventArgs.Parameter ?? ""));
        }

        #endregion

        #endregion
    }
}