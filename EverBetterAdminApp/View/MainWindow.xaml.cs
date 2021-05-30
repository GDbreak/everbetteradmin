using EverBetterAdminApp.Helpers;
using EverBetterAdminApp.Services;
using EverBetterAdminApp.View;
using EverBetterAdminApp.ViewModel;
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
using DataAccess;
using DataAccess.Models;

namespace EverBetterAdminApp.View
{
 
    public partial class MainWindow : Window
    {
        #region DataMembers

        private MainWindowViewModel viewModel;
        private OAuthService oAuthService;

        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            viewModel = (MainWindowViewModel)base.DataContext;
            oAuthService = ((App)Application.Current).oAuthService;

        }
        #endregion

        #region Events
        private async void Logoutbtn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWnd = null;

            Logoutbtn.Content = "Signing out...";

            bool result = await oAuthService.Logout();

            if (result)
            {
                loginWnd = new LoginWindow();
                Application.Current.MainWindow = loginWnd;
                loginWnd.Show();
                this.Close();
            }
            else
            {
                Logoutbtn.IsEnabled = true;
                Logoutbtn.Content = "Log Out";
            }
        }


        private async void SearchUsersbtn_Click(object sender, RoutedEventArgs e)
        {

            using(DataAccessService das = new DataAccessService(oAuthService.accessToken) )
            {
                IEnumerable<UsersResource> users = await das.GetUsers();
                foreach (var user in users)
                {

                }
            }


        }

        #endregion


    }
}
