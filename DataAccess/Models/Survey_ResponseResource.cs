using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Survey Responses.
    /// </summary>
    public class Survey_ResponseResource
    {
        /// <summary>
        /// The ID of the Survey Response.
        /// </summary>
        public long Survey_ResponseID { get; set; }
        /// <summary>
        /// The pre-defined text of the response.
        /// </summary>
        public string ResponseText { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
    }
}
