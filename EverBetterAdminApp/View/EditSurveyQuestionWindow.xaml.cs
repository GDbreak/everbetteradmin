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

    public partial class EditSurveyQuestionWindow : Window
    {

        private EditSurveyQuestionViewModel viewModel;
        public EditSurveyQuestionWindow(int survey_QuestionId)
        {
            InitializeComponent();
            viewModel = (EditSurveyQuestionViewModel)base.DataContext;
        }
    }
}
