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


    public class ManageSurveyPagesViewModel : BaseViewModel
    {
        #region DataMembers
        private IEnumerable<Survey_PageResource> _survey_Pages;

        #endregion

        #region Constructors

        public ManageSurveyPagesViewModel() : base()
        {

        }

        #endregion

        #region Properties

        public IEnumerable<Survey_PageResource> survey_Pages
        {
            get
            {
                return _survey_Pages;
            }
            set
            {
                if (value == _survey_Pages)
                    return;

                _survey_Pages = value;
                raisePropertyChanged("survey_Pages");
            }
        }

        #endregion

        #region Methods

        public async Task GetAllSurveyPages()
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                survey_Pages = await das.GetAllSurveyPages();
                return;
            }
        }

        public async Task AddSurveyPage(string survey_PageText, int sortOrder)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_PageResource srr = await das.AddSurveyPage(survey_PageText, sortOrder);
                MessageBox.Show("Successfully added " + srr.Header);
                
                await GetAllSurveyPages();
                return;
            }
        }

        public async Task DeleteSurveyPage(long survey_PageId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                Survey_PageResource srr = await das.DeleteSurveyPage(survey_PageId);
                MessageBox.Show("Successfully deleted " + srr.Header);
                await GetAllSurveyPages();
                return;
            }
        }

        #endregion

    }

}
