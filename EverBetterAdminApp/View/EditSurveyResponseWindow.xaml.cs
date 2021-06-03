﻿using EverBetterAdminApp.ViewModel;
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
    public partial class EditSurveyResponseWindow : Window
    {

        private EditSurveyResponseViewModel viewModel;
        public EditSurveyResponseWindow(int survey_ResponseId)
        {
            InitializeComponent();
            viewModel = (EditSurveyResponseViewModel)base.DataContext;
        }
    }
}
