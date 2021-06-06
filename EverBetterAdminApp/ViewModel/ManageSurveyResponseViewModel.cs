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


    public class ManageSurveyResponsesViewModel : BaseViewModel
    {
        #region DataMembers
        private OAuthService _oAuthService;
        private IEnumerable<Survey_ResponseResource> _survey_Responses;

        #endregion

        #region Constructors

        public ManageSurveyResponsesViewModel()
        {
            _oAuthService = ((App)Application.Current).oAuthService;

        }

        #endregion

        #region Properties

        public IEnumerable<Survey_ResponseResource> survey_Responses
        {
            get
            {
                return _survey_Responses;
            }
            set
            {
                if (value == _survey_Responses)
                    return;

                _survey_Responses = value;
                raisePropertyChanged("survey_Responses");
            }
        }

        #endregion

        #region Methods

        public async Task GetAllSurveyResponses()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                _survey_Responses = await das.GetAllSurveyResponses();
                return;
            }
        }

        public async Task AddSurveyResponse(string survey_ResponseText)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                _survey_Responses = await das.AddSurveyResponse(survey_ResponseText);
                await GetAllSurveyResponses();
                return;
            }
        }

        public async Task DeleteSurveyResponse(int survey_ResponseId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                _survey_Responses = await das.DeleteSurveyResponse(survey_ResponseId);
                await GetAllSurveyResponses();
                return;
            }
        }

        #endregion

    }

}
