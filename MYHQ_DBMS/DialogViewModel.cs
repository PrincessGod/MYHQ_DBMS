using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MYHQ_DBMS
{
    public class DialogsViewModel 
    {
        public DialogsViewModel()
        {
        }

        #region SAMPLE 3


        public ICommand RunAddMemberDialogCommand
        {
            get
            {
                return new AnotherCommandImplementation(ExecuteRunAddMemberDialog);
            }
        }

        public ICommand RunDeleteMemberDialogCommand
        {
            get
            {
                return new AnotherCommandImplementation(ExecuteRunDeleteMemberDialog);
            }
        }

        public ICommand RunEditMemberDialogCommand
        {
            get
            {
                return new AnotherCommandImplementation(ExecuteRunEditMemberDialog);
            }
        }
        //public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog); C#6.0

        public ICommand RunExtendedDialogCommand
        {
            get
            {
                return new AnotherCommandImplementation(ExecuteRunExtendedDialog);
            }
            
        }

        //public ICommand RunExtendedDialogCommand => new AnotherCommandImplementation(ExecuteRunExtendedDialog); C#6.0

        private async void ExecuteRunAddMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new MemberEditDialog
            {
                //DataContext = new SampleDialogViewModel()
            };
            
            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));

            //if (result != null && Equals(result, true))
            //{
            //    //do some thing when result is true
            //    var view1 = new WitingDialog
            //    {
            //        //DataContext = new SampleDialogViewModel()
            //    };

            //    //show the dialog
            //    var result1 = await DialogHost.Show(view1, "RootDialog", AddMemberDialogClosingEventHandler);
            //}
           
        }


        private void AddMemberDialogClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
            
            if (eventArgs.Parameter is Boolean && (bool)eventArgs.Parameter == false) return;
            
            //Something wrong , cancle closing...
            eventArgs.Cancel();

            //have to update the "session" with some new content!
            if (eventArgs.Parameter is Boolean && (bool)eventArgs.Parameter == true)
            {
                eventArgs.Session.UpdateContent(new WitingDialog());
            }


        }

        private async void ExecuteRunDeleteMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new SimpleMessageDialog
            {
                Message = { Text = string.Format("你确定要删除\r\n 用户名：{0}  账户：{1} ?", ((Test2)o).V1, ((Test2)o).V4) , 
                    TextAlignment = System.Windows.TextAlignment.Center  }
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));


        }

        private async void ExecuteRunEditMemberDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new MemberEditDialog
            {
                DataContext = (Test2)o,
                Title = { Text = "修改用户"},
                PassW = { Text = "新密码"}

            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", AddMemberDialogClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));


        }
        private async void ExecuteRunExtendedDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new MemberEditDialog
            {
                //DataContext = new SampleDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
        {
            var x = eventargs.Session.Content;
            Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");
        }

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false) return;

            //OK, lets cancel the close...
            eventArgs.Cancel();

            //...now, lets update the "session" with some new content!
           // eventArgs.Session.UpdateContent(new SampleProgressDialog());
            //note, you can also grab the session when the dialog opens via the DialogOpenedEventHandler

            //lets run a fake operation for 3 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        #endregion
         
    }
}
