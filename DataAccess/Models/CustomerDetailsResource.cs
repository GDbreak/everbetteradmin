
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Customers. Inherits from the resource for all Users.
    /// </summary>
    public class CustomerDetailsResource : UsersResource
    {
        /// <summary>
        /// All payment processor customer ids for the customer.
        /// </summary>
        public IEnumerable<BillingResource> Billings { get; set; }
        /// <summary>
        /// The current clinician for the customer.
        /// </summary>
        public ClinicianResource CurrentClinician { get; set; }
        /// <summary>
        /// The customer's clinician history.
        /// </summary>
        public IEnumerable<Users_Connection_ChangeResource> Users_Connection_Changes { get; set; }
        /// <summary>
        /// The customer's survey responses.
        /// </summary>
        public IEnumerable<Users_ResponseResource> Users_Responses { get; set; }
    }
}
