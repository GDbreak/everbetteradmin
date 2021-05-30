using EverBetterAdminApp.Helpers;
using EverBetterAdminApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace EverBetterAdminApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Data Members
        private OAuthService _oAuthService;
        #endregion
        #region Constructors
        public MainWindowViewModel()
        {
            _oAuthService = ((App)Application.Current).oAuthService;
        }
        #endregion
        #region Properties
        public OAuthService service
        {
            get
            {
                return _oAuthService;
            }
        }
        #endregion
    }
}
