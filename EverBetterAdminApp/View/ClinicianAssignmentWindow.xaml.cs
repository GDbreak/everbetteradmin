using DataAccess.Models;
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
using System.Windows.Shapes;

namespace EverBetterAdminApp.View
{

    public partial class ClinicianAssignmentWindow : Window
    {

        #region DataMembers

        private ClinicianAssignmentViewModel viewModel;

        #endregion



        #region Constructors

        public ClinicianAssignmentWindow(Guid usersId)
        {
            InitializeComponent();
            ClinicianStackPanel.Visibility = Visibility.Hidden;
            viewModel = (ClinicianAssignmentViewModel)base.DataContext;
            viewModel.GetUserResponses(usersId);
            viewModel.GetCustomerResource(usersId);
            viewModel.GetMatchedClinicians(usersId);
        }

        #endregion

        #region Events

        private async void MatchedClinicianListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClinicianStackPanel.Visibility = Visibility.Visible;

            ClinicianResource clinicianResource =  (ClinicianResource)MatchedClinicianListView.SelectedItems[0];

            await viewModel.GetClinician(clinicianResource.UsersID);

        }

        #endregion

        private async void ApproveBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            btn.Content = "Approving...";

            if(await viewModel.AssignClinician(Detailstxt.Text))
            {
                MessageBox.Show("Clinician has been assigned");
                this.Close();
            }
            else
            {
                MessageBox.Show("There was an error.");
                                btn.IsEnabled = true;
                btn.Content = "Approve";
            }
        }
    }
}
