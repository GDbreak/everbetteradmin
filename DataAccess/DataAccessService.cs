using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DataAccess.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DataAccess
{
    public class DataAccessService : IDisposable
    {

        #region DataMembers

        private string API;
        private bool _disposed = false;
        private RestClient client;
        private string accessToken;

        #endregion

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
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<List<UsersResource>>(response.Content);
        }


        public async Task<CustomerDetailsResource> GetCustomerByID(Guid usersId)
        {
            RestRequest request = new RestRequest("Customer/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<CustomerDetailsResource>(response.Content);
        }

        public async Task<IEnumerable<Users_ResponseResource>> GetUsersResponseByUsersID(Guid usersId)
        {
            RestRequest request = new RestRequest("Users_Response/users/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<Users_ResponseResource>>(response.Content);
        }


        public async Task<IEnumerable<ClinicianResource>> GetMatchedClinicians(Guid usersId)
        {
            RestRequest request = new RestRequest("Clinician/matched/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<ClinicianResource>>(response.Content);
        }

        public async Task<ClinicianDetailsResource> GetClinician(Guid usersId)
        {
            RestRequest request = new RestRequest("Clinician/" + usersId.ToString(), Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
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
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<Survey_PageDetailsResource>>(response.Content);
        }

        #region Survey Response
        public async Task<IEnumerable<Survey_ResponseResource>> GetAllSurveyResponses()
        {
            RestRequest request = new RestRequest("Survey_Response", Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<Survey_ResponseResource>>(response.Content);
        }

        public async Task<Survey_ResponseResource> AddSurveyResponse(string survey_ResponseText)
        {
            RestRequest request = new RestRequest("Survey_Response", Method.POST);
            request.AddHeader("authorization", "Bearer " + accessToken);
            Dictionary<string, string> ds = new Dictionary<string, string>();
            ds.Add("responseText", survey_ResponseText);
            request.AddJsonBody(ds);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_ResponseResource>(response.Content);
        }

        public async Task<Survey_ResponseResource> DeleteSurveyResponse(long survey_ResponseId)
        {
            RestRequest request = new RestRequest("Survey_Response/" + survey_ResponseId.ToString(), Method.DELETE);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_ResponseResource>(response.Content);
        }

        #endregion

        #region Survey Question
        public async Task<IEnumerable<Survey_QuestionResource>> GetAllSurveyQuestions()
        {
            RestRequest request = new RestRequest("Survey_Question", Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<Survey_QuestionResource>>(response.Content);
        }

        public async Task<Survey_QuestionResource> AddSurveyQuestion(string survey_QuestionText)
        {

            RestRequest request = new RestRequest("Survey_Question", Method.POST);
            request.AddHeader("authorization", "Bearer " + accessToken);
            Dictionary<string, string> ds = new Dictionary<string, string>();
            ds.Add("QuestionText", survey_QuestionText);
            request.AddJsonBody(ds);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_QuestionResource>(response.Content);
        }

        public async Task<Survey_QuestionResource> DeleteSurveyQuestion(long survey_QuestionId)
        {
            RestRequest request = new RestRequest("Survey_Question/" + survey_QuestionId.ToString(), Method.DELETE);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_QuestionResource>(response.Content);
        }

        #endregion


        #region Survey Page
        public async Task<IEnumerable<Survey_PageResource>> GetAllSurveyPages()
        {
            RestRequest request = new RestRequest("Survey_Page", Method.GET);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<IEnumerable<Survey_PageResource>>(response.Content);
        }

        public async Task<Survey_PageResource> AddSurveyPage(string survey_PageText, int sortOrder)
        {

            RestRequest request = new RestRequest("Survey_Page", Method.POST);
            request.AddHeader("authorization", "Bearer " + accessToken);
            Dictionary<string, string> ds = new Dictionary<string, string>();
            ds.Add("header", survey_PageText);
            ds.Add("header", survey_PageText);
            request.AddJsonBody(ds);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_PageResource>(response.Content);
        }

        public async Task<Survey_PageResource> DeleteSurveyPage(long survey_PageId)
        {
            RestRequest request = new RestRequest("Survey_Page/" + survey_PageId.ToString(), Method.DELETE);
            request.AddHeader("authorization", "Bearer " + accessToken);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                JObject json = JObject.Parse(response.Content.ToString());
                throw new Exception(json["detail"].ToString());
            }
            return JsonConvert.DeserializeObject<Survey_PageResource>(response.Content);
        }

        #endregion
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


