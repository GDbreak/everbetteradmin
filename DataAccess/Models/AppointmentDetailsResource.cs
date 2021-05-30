using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Appointments.
    /// </summary>
    public class AppointmentDetailsResource
    {
        /// <summary>
        /// The unique ID of the Appointment.
        /// </summary>
        public long AppointmentID { get; set; }
        /// <summary>
        /// The title of the appointment.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Details describing the appointment.
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// The datetime when the appointment starts.
        /// </summary>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// The datetime when the appointment ends.
        /// </summary>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The GUID of the user requesting the appointment.
        /// </summary>
        public Guid Requester_UsersID { get; set; }
        /// <summary>
        /// The GUID of the user who must approve the appointment
        /// </summary>
        public Guid Approver_UsersID { get; set; }
        /// <summary>
        /// The current state enum integer of the appointment.
        /// </summary>
        public int StateID { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDatetime { get; set; }
        /// <summary>
        /// All changes that have been made to the appointment.
        /// </summary>
        public IEnumerable<Appointment_ChangeResource> Appointment_Changes { get; set; }

    }
}
