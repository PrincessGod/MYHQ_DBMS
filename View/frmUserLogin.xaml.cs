using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Input;

namespace MYHQ_DBMS.View
{
    /// <summary>
    ///     frmSingelTargetPlaybacks.xaml 的交互逻辑
    /// </summary>
    public partial class FrmUserLogin
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     回车键触发按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var peer = new ButtonAutomationPeer(btnOK);

                var invokeProv = peer.GetPattern(PatternInterface.Invoke)
                    as IInvokeProvider;

                if (invokeProv != null) invokeProv.Invoke();
            }
        }

        private void FrmUserLogin_OnLoaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(NameTextBox);
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

        #endregion
    }
}