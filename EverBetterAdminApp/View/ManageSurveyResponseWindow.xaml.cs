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
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ManageSurveyResponseWindow : Window
    {
        #region DataMembers

        private ManageSurveyResponsesViewModel viewModel;
        #endregion

        #region Constructors
        public ManageSurveyResponseWindow()
        {
            InitializeComponent();
            viewModel = (ManageSurveyResponsesViewModel)base.DataContext;
            viewModel.GetAllSurveyResponses();
        }

        #endregion

        #region Events

        private async void DeleteResponse_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete " +
                btn.DataContext.GetType().GetProperty("ResponseText").GetValue(btn.DataContext, null)
                + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    await viewModel.DeleteSurveyResponse((long)btn.DataContext.GetType().GetProperty("Survey_ResponseID").GetValue(btn.DataContext, null));
                }
            }
        }

        private async void CreateResponse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Responsetxt.Text.Length > 0)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to add " + Responsetxt.Text + "?", "Create Confirmation", System.Windows.MessageBoxButton.YesNo);
                    {
                        if (messageBoxResult == MessageBoxResult.Yes)

                            await viewModel.AddSurveyResponse(Responsetxt.Text);

                    }
                }
                else
                {
                    MessageBox.Show("Cannot add a blank response.");
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
    
        }


        #endregion

    }
}
