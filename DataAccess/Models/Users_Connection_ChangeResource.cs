using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all User Connection Changes.
    /// </summary>
    public class Users_Connection_ChangeResource
    {
        /// <summary>
        /// The ID of the User Connection Change.
        /// </summary>
        public long Users_Connection_ChangeID { get; set; }
        /// <summary>
        /// The ID of the User Connection for the change.
        /// </summary>
        public Guid Users_ConnectionID { get; set; }
        /// <summary>
        /// The GUID of the user who made the change.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// Details describing why the change was made.
        /// </summary>
        public string Details { get; set; }
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
