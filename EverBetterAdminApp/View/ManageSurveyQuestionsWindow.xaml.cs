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
    public partial class ManageSurveyQuestionsWindow : Window
    {
        #region DataMembers

        private ManageSurveyQuestionsViewModel viewModel;
        #endregion

        #region Constructors
        public ManageSurveyQuestionsWindow()
        {
            InitializeComponent();
            viewModel = (ManageSurveyQuestionsViewModel)base.DataContext;
            viewModel.GetAllSurveyQuestions();
        }

        #endregion

        #region Events

        private async void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete " +
                btn.DataContext.GetType().GetProperty("QuestionText").GetValue(btn.DataContext, null)
                + "?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            {
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    await viewModel.DeleteSurveyQuestion((long)btn.DataContext.GetType().GetProperty("Survey_QuestionID").GetValue(btn.DataContext, null));
                }
            }
        }

        private async void CreateQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Questiontxt.Text.Length > 0)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to add " + Questiontxt.Text + "?", "Create Confirmation", System.Windows.MessageBoxButton.YesNo);
                    {
                        if (messageBoxResult == MessageBoxResult.Yes)

                            await viewModel.AddSurveyQuestion(Questiontxt.Text);

                    }
                }
                else
                {
                    MessageBox.Show("Cannot add a blank Question.");
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
