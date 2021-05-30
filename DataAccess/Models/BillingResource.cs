using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all billing resources.
    /// </summary>
    public class BillingResource
    {
        /// <summary>
        /// The ID of the billing resource.
        /// </summary>
        public long BillingID { get; set; }
        /// <summary>
        /// The user the billing resource is associated with.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The name of the processor the processor ID belongs to.
        /// </summary>
        public string Processor { get; set; }
        /// <summary>
        /// The ID from the processor that distinguishes the unique user in the processor's system.
        /// </summary>
        public string ProcessorID { get; set; }
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
