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

    public partial class EditSurveyPageWindow : Window
    {

        private EditSurveyPageViewModel viewModel;
        public EditSurveyPageWindow(int survey_PageId)
        {
            InitializeComponent();
            viewModel = (EditSurveyPageViewModel)base.DataContext;
        }
    }
}
