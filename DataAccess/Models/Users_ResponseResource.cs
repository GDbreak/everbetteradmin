using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all User Responses.
    /// </summary>
    public class Users_ResponseResource
    {
        /// <summary>
        /// The ID of the User Response.
        /// </summary>
        public long Users_ResponseID { get; set; }
        /// <summary>
        /// The ID of the Survey Question the response is for.
        /// </summary>
        public long Survey_QuestionID { get; set; }
        /// <summary>
        /// The GUID of the user who submitted the response.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The ID of the Survey Response that was used, when applicable.
        /// </summary>
        public long? Survey_ResponseID { get; set; }
        /// <summary>
        /// The text of the survey question at the time of submission.
        /// </summary>
        public string QuestionText { get; set; }
        /// <summary>
        /// The text of the response at the time of submission.
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
