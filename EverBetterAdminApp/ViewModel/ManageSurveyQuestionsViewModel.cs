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


    public class ManageSurveyQuestionsViewModel : BaseViewModel
    {
        #region DataMembers
        private IEnumerable<Survey_QuestionResource> _survey_Questions;

        #endregion

        #region Constructors

        public ManageSurveyQuestionsViewModel() : base()
        {

        }

        #endregion

        #region Properties

        public IEnumerable<Survey_QuestionResource> survey_Questions
        {
            get
            {
                return _survey_Questions;
            }
            set
            {
                if (value == _survey_Questions)
                    return;

                _survey_Questions = value;
                raisePropertyChanged("survey_Questions");
            }
        }

        #endregion

        #region Methods

        public async Task GetAllSurveyQuestions()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                survey_Questions = await das.GetAllSurveyQuestions();
                return;
            }
        }

        public async Task AddSurveyQuestion(string survey_QuestionText)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_QuestionResource srr = await das.AddSurveyQuestion(survey_QuestionText);
                MessageBox.Show("Successfully added " + srr.Placeholder);
                
                await GetAllSurveyQuestions();
                return;
            }
        }

        public async Task DeleteSurveyQuestion(long survey_QuestionId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_QuestionResource srr = await das.DeleteSurveyQuestion(survey_QuestionId);
                MessageBox.Show("Successfully deleted " + srr.Placeholder);
                await GetAllSurveyQuestions();
                return;
            }
        }

        #endregion

    }

}
