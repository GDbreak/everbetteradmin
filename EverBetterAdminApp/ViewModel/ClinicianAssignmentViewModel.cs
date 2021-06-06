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
    public class ClinicianAssignmentViewModel : BaseViewModel
    {
        #region DataMembers

        private IEnumerable<Users_ResponseResource> _users_Responses;
        private CustomerDetailsResource _customerDetailsResource;
        private IEnumerable<ClinicianResource> _matchedClinicians;
        private ClinicianDetailsResource _clinicianDetailsResource;

        #endregion

        #region Constructors
        public ClinicianAssignmentViewModel() : base()
        {
        }


        #endregion

        #region Properties

        public IEnumerable<Users_ResponseResource> users_Responses
        {
            get
            {
                return _users_Responses;
            }
            set
            {
                if (value == _users_Responses)
                    return;

                _users_Responses = value;
                raisePropertyChanged("users_Responses");
            }
        }

        public CustomerDetailsResource customerDetailsResource
        {
            get
            {
                return _customerDetailsResource;
            }
            set
            {
                if (value == _customerDetailsResource)
                    return;

                _customerDetailsResource = value;
                raisePropertyChanged("customerDetailsResource");
            }
        }

        public IEnumerable<ClinicianResource> matchedClinicians
        {
            get
            {
                return _matchedClinicians;
            }
            set
            {
                if (value == _matchedClinicians)
                    return;

                _matchedClinicians = value;
                raisePropertyChanged("matchedClinicians");
            }
        }

        public ClinicianDetailsResource clinicianDetailsResource
        {
            get
            {
                return _clinicianDetailsResource;
            }
            set
            {
                if (value == _clinicianDetailsResource)
                    return;

                _clinicianDetailsResource = value;
                raisePropertyChanged("clinicianDetailsResource");
            }
        }

        #endregion

        #region Methods


        public async Task GetUserResponses(Guid usersId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                users_Responses = await das.GetUsersResponseByUsersID(usersId);
                return;
            }
        }


        public async Task GetCustomerResource(Guid usersId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                customerDetailsResource = await das.GetCustomerByID(usersId);
                return;
            }
        }

        public async Task GetMatchedClinicians(Guid usersId)
        {

            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                matchedClinicians = await das.GetMatchedClinicians(usersId);
                return;
            }
        }

        public async Task GetClinician(Guid usersId)
        {
            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                clinicianDetailsResource = await das.GetClinician(usersId);
                return;
            }
        }

        public async Task<bool> AssignClinician(string details = null)
        {
            using (DataAccessService das = new DataAccessService(_oAuthService.accessToken))
            {
                await das.AssignClinician(customerDetailsResource.UsersID,  clinicianDetailsResource.UsersID, details);
                return true;
            }
        }

        #endregion
    }
}
