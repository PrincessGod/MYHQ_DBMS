using MYHQ_DBMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MYHQ_DBMS
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)  
            {
                var view = new frmUserLogin
                {
                    DataContext = new LoginViewModel()
                };

                view.Show();
            }

    }
}
