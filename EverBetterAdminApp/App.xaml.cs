using EverBetterAdminApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Telerik.Windows.Controls;

namespace EverBetterAdminApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Data Members

        private OAuthService _oAuthService;

        #endregion

        #region Constructors
        public App()
        {
            StyleManager.ApplicationTheme = new Telerik.Windows.Controls.Office2016Theme();
            this.InitializeComponent();
            _oAuthService = new OAuthService();
        }
        #endregion

        #region Properties
        public OAuthService oAuthService
        {
            get
            {
                return _oAuthService;
            }
        }
        #endregion
    }
}
