using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DataAccess
{
    public class DataAccessService : IDisposable
    {
        private string API;
        private bool _disposed = false;
        private RestClient client;
        private string accessToken;

        #region Constructors

        public DataAccessService(string _accessToken)
        {
            API = ConfigurationManager.AppSettings["API:Endpoint"];
            client = new RestClient(API);
            accessToken = _accessToken;
        }



        #endregion

        #region Methods

        public async Task<IEnumerable<UsersResource>> GetUsers()
        {
            RestRequest request = new RestRequest("Users", Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<List<UsersResource>>(response.Content);
        }


        public async Task<CustomerDetailsResource> GetCustomerByID(Guid usersId)
        {
            RestRequest request = new RestRequest("Customer/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<CustomerDetailsResource>(response.Content);
        }

        public async Task<IEnumerable<Users_ResponseResource>> GetUsersResponseByUsersID(Guid usersId)
        {
            RestRequest request = new RestRequest("Users_Response/users/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Users_ResponseResource>>(response.Content);
        }


        public async Task<IEnumerable<ClinicianResource>> GetMatchedClinicians(Guid usersId)
        {
            RestRequest request = new RestRequest("Clinician/matched/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<ClinicianResource>>(response.Content);
        }

        public async Task<ClinicianDetailsResource> GetClinician(Guid usersId)
        {
            RestRequest request = new RestRequest("Clinician/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ClinicianDetailsResource>(response.Content);
        }

        public async Task<bool> AssignClinician(Guid customerId, Guid clinicianId, string details)
        {
            RestRequest request = new RestRequest("Customer/assign/" + customerId.ToString(), Method.POST);
            request.AddHeader("authorization", "Bearer " + accessToken);
            request.RequestFormat = DataFormat.Json;
            Dictionary<string, string> ds = new Dictionary<string, string>();
            ds.Add("clinician_UsersID", clinicianId.ToString());
            ds.Add("details", details);
            request.AddJsonBody(ds);
            IRestResponse response = await client.ExecuteAsync(request);
            return response.IsSuccessful;
        }

        public async Task<IEnumerable<Survey_PageDetailsResource>> GetSurveyData()
        {
            RestRequest request = new RestRequest("Survey_Page", Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Survey_PageDetailsResource>>(response.Content);
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // free managed resources
                }
            }
            // free native resources if there are any.
            _disposed = true;

        }

        #endregion

    }
}


