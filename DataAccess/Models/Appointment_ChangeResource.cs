using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Appointment Changes.
    /// </summary>
    public class Appointment_ChangeResource
    {
        /// <summary>
        /// The unique ID of the Appointment Change.
        /// </summary>
        public long Appointment_ChangeID { get; set; }
        /// <summary>
        /// The unique ID of the user who made the change
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// Details describing the change.
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// The datetime of the change.
        /// </summary>
        public DateTime ChangeDateTime { get; set; }
        /// <summary>
        /// The ID of the appointment that was changed.
        /// </summary>
        public long AppointmentID { get; set; }
        /// <summary>
        /// The ID of the state the appointment was changed to.
        /// </summary>
        public int StateID { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDatetime { get; set; }
    }
}
