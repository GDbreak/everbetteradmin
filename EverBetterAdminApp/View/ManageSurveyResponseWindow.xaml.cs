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

        private ManageSurveyResponseViewModel viewModel;
        #endregion

        #region Constructors
        public ManageSurveyResponseWindow(int survey_ResponseId)
        {
            InitializeComponent();
            viewModel = (ManageSurveyResponseViewModel)base.DataContext;
        }

        #endregion

        #region Events

        private void DeleteResponse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreateResponse_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

    }
}
