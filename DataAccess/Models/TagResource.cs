using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Tags.
    /// </summary>
    public class TagResource
    {
        /// <summary>
        /// The ID of the Tag.
        /// </summary>
        public int TagID { get; set; }
        /// <summary>
        /// The description of the tag
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// The GUID of the user who made the tag.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>

        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>

        public DateTime CreatedDatetime { get; set; }
    }
}
