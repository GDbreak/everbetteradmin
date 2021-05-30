using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{

    /// <summary>
    /// The detailed resource for all AV Rooms.
    /// </summary>
    public class AV_RoomDetailsResource
    {
        /// <summary>
        /// The ID of the AV Room.
        /// </summary>
        public long AV_RoomID { get; set; }
        /// <summary>
        /// The ID of the associated appointment. Appointments can only have one AV Room each.
        /// </summary>
        public int AppointmentID { get; set; }
        /// <summary>
        /// The AV service provider ID for the session.
        /// </summary>
        public string SessionID { get; set; }
        /// <summary>
        /// The ID of the user who created the AV Room and the leader of the AV session.
        /// This should always be the clinician.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// A collection of participants for the AV Room.
        /// </summary>
        public IEnumerable<AV_ParticipantResource> AV_Participants { get; set; }

    }
}
