using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all AV Participants.
    /// </summary>
    public class AV_ParticipantResource
    { 
      /// <summary>
      /// The ID of the AV Participant.
      /// </summary>
        public long AV_ParticipantID { get; set; }
        /// <summary>
        /// The ID of the user who is the participant. This should always be customers.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The ID of the AV Room that the participant is associated with.
        /// </summary>
        public long AV_RoomID { get; set; }
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
