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


