using System.Windows;
using MYHQ_DBMS.View;
using MYHQ_DBMS.ViewModel;

namespace MYHQ_DBMS
{
    /// <summary>
    ///     App.xaml 的交互逻辑
    /// </summary>
    public partial class App
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var view = new FrmUserLogin
            {
                DataContext = new LoginViewModel()
            };

            view.Show();
        }
    }
}