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
        private IEnumerable<Survey_ResponseResource> _survey_Responses;

        #endregion

        #region Constructors

        public ManageSurveyResponsesViewModel() : base()
        {

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
                survey_Responses = await das.GetAllSurveyResponses();
                return;
            }
        }

        public async Task AddSurveyResponse(string survey_ResponseText)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_ResponseResource srr = await das.AddSurveyResponse(survey_ResponseText);
                MessageBox.Show("Successfully added " + srr.ResponseText);
                
                await GetAllSurveyResponses();
                return;
            }
        }

        public async Task DeleteSurveyResponse(long survey_ResponseId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_ResponseResource srr = await das.DeleteSurveyResponse(survey_ResponseId);
                MessageBox.Show("Successfully deleted " + srr.ResponseText);
                await GetAllSurveyResponses();
                return;
            }
        }

        #endregion

    }

}
