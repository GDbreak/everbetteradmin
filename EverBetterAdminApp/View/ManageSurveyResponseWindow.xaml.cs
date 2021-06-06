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
            //await viewModel.DeleteSurveyResponse(Responsetxt.Text);
        }

        private async void CreateResponse_Click(object sender, RoutedEventArgs e)
        {
            await viewModel.AddSurveyResponse(Responsetxt.Text);
        }

        #endregion

    }
}
