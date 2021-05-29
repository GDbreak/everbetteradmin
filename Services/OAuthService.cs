using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.ComponentModel;
using System.IO;
using Auth0.OidcClient;
using EverBetterAdminApp.Helpers;
using IdentityModel.OidcClient;
using System.Threading.Tasks;
using IdentityModel.OidcClient.Browser;
using System.Security.Principal;

namespace EverBetterAdminApp.Services
{

    public class OAuthService : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Data Members

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Data Members

        private App _app;
        private Auth0Client client;
        private String _accessToken;
        private String _identityToken;
        private String _firstName;
        private String _userName;
        private String _lastName;
        //private Dictionary<string, string> _claims;

        #endregion

        #region Constructors

        public OAuthService()
        {
            _app = (App)Application.Current;
        }

        #endregion

        #region Members

        protected void raisePropertyChanged(String _propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(_propertyName));
        }

        #endregion


        #region Properties

        public String accessToken
        {
            get
            {
                return _accessToken;
            }
            set
            {
                if (value == _accessToken)
                    return;
                _accessToken = value;
                raisePropertyChanged("accessToken");
            }
        }

        public String identityToken
        {
            get
            {
                return _identityToken;
            }
            set
            {
                if (value == _identityToken)
                    return;
                _identityToken = value;
                raisePropertyChanged("identityToken");
            }
        }

        public String firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == _firstName)
                    return;
                _firstName = value;
                raisePropertyChanged("firstName");
            }
        }


        public String userName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (value == _userName)
                    return;
                _userName = value;
                raisePropertyChanged("userName");
            }
        }



        public String lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == _lastName)
                    return;
                _lastName = value;
                raisePropertyChanged("lastName");
            }
        }

        //public Dictionary<string, string> claims
        //{

        //    get
        //    {
        //        return _claims;
        //    }
        //    set
        //    {
        //        if (value == _claims)
        //            return;
        //        _claims = value;
        //        raisePropertyChanged("claims");
        //    }
        //}

        #endregion

        #region Methods

        public async Task<bool> Login()
        {

            string domain = ConfigurationManager.AppSettings["Auth0:Domain"];
            string clientId = ConfigurationManager.AppSettings["Auth0:ClientId"];

            client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = domain,
                ClientId = clientId,
                Browser = new WebViewBrowserChromium()
            });

            LoginResult login = await client.LoginAsync();
            if (login.AccessToken != null)
            {
                accessToken = login.AccessToken;
                identityToken = login.IdentityToken;
                firstName = login.User.Identity.Name;
                userName = login.User.Identity.Name;
                lastName = login.User.Identity.Name;

                //Dictionary<string, string> ds = new Dictionary<string, string>();
                //foreach (var claim in login.User.Claims)
                //{
                //    ds.Add(claim.Type, claim.Value);
                //}
                //claims = ds;
                return true;
            }
            return false;

        }

        private async Task<bool> clearUserData()
        {
            accessToken = null;
            identityToken = null;
            firstName = null;
            userName = null;
            lastName = null;
            return true;
        }

        public async Task<bool> Logout()
        {
            BrowserResultType browserResult = await client.LogoutAsync();

            if (browserResult != BrowserResultType.Success)
            {
                return false;
            }
            if (await clearUserData())
            {
                return true;
            }
            return false;
        }

        #endregion

    }


}

