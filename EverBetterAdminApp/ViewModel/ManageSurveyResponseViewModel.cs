using DataAccess.Models;
using EverBetterAdminApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverBetterAdminApp.ViewModel
{


    public class EditSurveyResponseViewModel : BaseViewModel
    {
        #region DataMembers

        private IEnumerable<Survey_ResponseResource> _survey_Responses;

        #endregion

        #region Constructors

        public EditSurveyResponseViewModel()
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


    }

}
