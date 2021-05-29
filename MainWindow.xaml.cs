using EverBetterAdminApp.Helpers;
using EverBetterAdminApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EverBetterAdminApp
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Data Members
        private OAuthService _oAuthService;
        #endregion
        #region Constructors
        public MainWindowViewModel()
        {
            _oAuthService = ((App)Application.Current).oAuthService;
        }
        #endregion
        #region Properties
        public OAuthService service
        {
            get
            {
                return _oAuthService;
            }
        }
        #endregion
    }
    public partial class MainWindow : Window
    {
        #region DataMembers

        private MainWindowViewModel viewModel;

        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowViewModel)base.DataContext;
            Welcometxt.Text = "Welcome " + viewModel.service.userName;
        }
        #endregion

        #region Events
        private async void Logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWnd = null;

            bool result = await((App)Application.Current).oAuthService.Logout();

            if (result)
            {
                loginWnd = new LoginWindow();
                Application.Current.MainWindow = loginWnd;
                loginWnd.Show();
                this.Close();
            }
        }
        #endregion

        private void RadGridView_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {

        }
    }
}
