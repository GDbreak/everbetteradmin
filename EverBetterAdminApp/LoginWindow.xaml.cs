using Auth0.OidcClient;
using EverBetterAdminApp.Helpers;
using EverBetterAdminApp.Services;
using IdentityModel.OidcClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EverBetterAdminApp
{
    public class LoginWindowViewModel : BaseViewModel
    {


        public LoginWindowViewModel()
        {


        }
    }
		public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).oAuthService;
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWnd = null;

            bool result = await ((App)Application.Current).oAuthService.Login();

            if (result)
            {
                mainWnd = new MainWindow();
                Application.Current.MainWindow = mainWnd;
                mainWnd.Show();
                this.Close();
            }
        }
    }
}
