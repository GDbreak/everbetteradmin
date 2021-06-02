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
using Telerik.Windows.Controls;

namespace EverBetterAdminApp.View
{
 
    public partial class MainWindow : Window
    {
        #region DataMembers

        private MainWindowViewModel viewModel;
        private OAuthService oAuthService;
        private RadGridView questionRowDetails;
        private RadGridView responseRowDetails;
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
            SearchUsersbtn.IsEnabled = false;

             await viewModel.GetCustomersWithoutClinicians();

            SearchUsersbtn.IsEnabled = true;

        }

        private async void SearchManageUsersbtn_Click(object sender, RoutedEventArgs e)
        {
            SearchManageUsersbtn.IsEnabled = false;

            await viewModel.GetUsers();

            SearchManageUsersbtn.IsEnabled = true;

        }

        private void CustomerListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClinicianAssignmentWindow wnd = null;

            if (CustomerListView.SelectedItems.Count < 1)
                return;

            UsersResource ur = (UsersResource)CustomerListView.SelectedItems[0];
            wnd = new ClinicianAssignmentWindow(ur.UsersID);
            wnd.Owner = this;
            wnd.ShowDialog();
        }


        private void ManageUsersListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClinicianAssignmentWindow wnd = null;

            if (CustomerListView.SelectedItems.Count < 1)
                return;

            UsersResource ur = (UsersResource)CustomerListView.SelectedItems[0];
            wnd = new ClinicianAssignmentWindow(ur.UsersID);
            wnd.Owner = this;
            wnd.ShowDialog();
        }
        #endregion

        private async void LoadSurveyPagebtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            btn.IsEnabled = false;
            btn.Content = "Loading...";

            await viewModel.GetSurveyPages();


            btn.Content = "Loaded...";
        }

        private void EditPageContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (SurveyPageGV.SelectedItem == null)
            {
                MessageBox.Show("No survey pages were selected.");
                return;
            }

            Survey_PageDetailsResource spdr = (Survey_PageDetailsResource)SurveyPageGV.SelectedItem;
            EditSurveyPageWindow wnd = new EditSurveyPageWindow(spdr.Survey_PageID);
            wnd.Owner = this;
            wnd.ShowDialog();
        }

        private void EditQuestionContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (questionRowDetails == null || questionRowDetails.SelectedItem == null)
            {
                MessageBox.Show("No survey questions were selected.");
                return;
            }

            Survey_QuestionDetailsResource sqdr = (Survey_QuestionDetailsResource)questionRowDetails.SelectedItem;
            EditSurveyPageWindow wnd = new EditSurveyPageWindow(sqdr.Survey_QuestionID);
            wnd.Owner = this;
            wnd.ShowDialog();
        }
        
        private void EditResponseContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (responseRowDetails == null || responseRowDetails.SelectedItem == null)
            {
                MessageBox.Show("No survey responses were selected.");
                return;
            }

            Survey_ResponseResource srr = (Survey_ResponseResource)responseRowDetails.SelectedItem;
            EditSurveyPageWindow wnd = new EditSurveyPageWindow((int)srr.Survey_ResponseID);
            wnd.Owner = this;
            wnd.ShowDialog();
        }

        private void SurveyPageGV_RowDetailsVisibilityChanged(object sender, Telerik.Windows.Controls.GridView.GridViewRowDetailsEventArgs e)
        {

            if (e.Visibility == Visibility.Visible)
            {

                questionRowDetails = e.DetailsElement.FindName("SurveyQuestionsGV") as RadGridView;

            }
    
        }

        private void SurveyQuestionsGV_RowDetailsVisibilityChanged(object sender, Telerik.Windows.Controls.GridView.GridViewRowDetailsEventArgs e)
        {

            if (e.Visibility == Visibility.Visible)
            {

                responseRowDetails = e.DetailsElement.FindName("SurveyResponsesGV") as RadGridView;

            }

        }
    }
}
