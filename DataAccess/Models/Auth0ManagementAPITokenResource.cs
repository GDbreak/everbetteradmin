using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models.Base
{
    /// <summary>
    /// The resource for all auth0 management tokens. Used internally for API access.
    /// </summary>
    public class Auth0ManagementAPITokenResource
    {
        /// <summary>
        /// The access token for the API.
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// How long until the token expires.
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// The scope of the token.
        /// </summary>
        public string scope { get; set; }
        /// <summary>
        /// Type of token.
        /// </summary>
        public string token_type { get; set; }
    }
}
