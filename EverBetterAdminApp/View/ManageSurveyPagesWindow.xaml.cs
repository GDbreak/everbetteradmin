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
    public partial class ManageSurveyPagesWindow : Window
    {
        #region DataMembers

        private ManageSurveyPagesViewModel viewModel;
        #endregion

        #region Constructors
        public ManageSurveyPagesWindow()
        {
            InitializeComponent();
            viewModel = (ManageSurveyPagesViewModel)base.DataContext;
            viewModel.GetAllSurveyPages();
        }

        #endregion

        #region Events

        private async void DeletePage_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete " +
                btn.DataContext.GetType().GetProperty("PageText").GetValue(btn.DataContext, null)
                + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    await viewModel.DeleteSurveyPage((long)btn.DataContext.GetType().GetProperty("Survey_PageID").GetValue(btn.DataContext, null));
                }
            }
        }

        private async void CreatePage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Pagetxt.Text.Length > 0)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to add " + Pagetxt.Text + "?", "Create Confirmation", System.Windows.MessageBoxButton.YesNo);
                    {
                        if (messageBoxResult == MessageBoxResult.Yes)

                            await viewModel.AddSurveyPage(Pagetxt.Text);

                    }
                }
                else
                {
                    MessageBox.Show("Cannot add a blank Page.");
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
