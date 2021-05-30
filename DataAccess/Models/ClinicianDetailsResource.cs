using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Clinicians. Inherits from the resource for all Users.
    /// </summary>
    public class ClinicianDetailsResource : UsersResource
    {
        /// <summary>
        /// The tags for the clinician.
        /// </summary>
        public IEnumerable<TagResource> Tags { get; set; }
        /// <summary>
        /// All schedules for the clinician.
        /// </summary>

        public IEnumerable<ScheduleResource> Schedules { get; set; }
        /// <summary>
        /// All customers for the clinician.
        /// </summary>

        public IEnumerable<CustomerResource> Customers { get; set; }

    }
}
