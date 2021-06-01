using DataAccess;
using DataAccess.Models;
using EverBetterAdminApp.Helpers;
using EverBetterAdminApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EverBetterAdminApp.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Data Members
        private OAuthService _oAuthService;
        private IEnumerable<UsersResource> _customersWithoutClinicians;
        private IEnumerable<UsersResource> _users;
        private IEnumerable<Survey_PageDetailsResource> _surveyPageDetails;
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

        public IEnumerable<UsersResource> customersWithoutClinicians
        {
            get
            {
                return _customersWithoutClinicians;
            }
            set
            {
                if (value == _customersWithoutClinicians)
                    return;

                _customersWithoutClinicians = value;
                raisePropertyChanged("customersWithoutClinicians");
            }
        }

        public IEnumerable<UsersResource> users
        {
            get
            {
                return _users;
            }
            set
            {
                if (value == _users)
                    return;

                _users = value;
                raisePropertyChanged("users");
            }
        }

        public IEnumerable<Survey_PageDetailsResource> SurveyPageDetails
        {
            get
            {
                return _surveyPageDetails;
            }
            set
            {
                if (value == _surveyPageDetails)
                    return;

                _surveyPageDetails = value;
                raisePropertyChanged("SurveyPageDetails");
            }
        }


        #endregion

        #region Methods

        public async Task GetCustomersWithoutClinicians()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                customersWithoutClinicians = await das.GetUsers();
                return;
            }
        }

        public async Task GetUsers()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                users = await das.GetUsers();
                return;
            }
        }

        public async Task GetSurveyPages()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                SurveyPageDetails = await das.GetSurveyData();
                return;
            }
        }

        #endregion
    }
}
