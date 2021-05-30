using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Text Channel Participants.
    /// </summary>
    public class Text_Channel_ParticipantResource
    {
        /// <summary>
        /// The unique ID of the Text Channel Participant.
        /// </summary>
        public long Text_Channel_ParticipantID { get; set; }
        /// <summary>
        /// The unique user ID of the user who is the participant of the channel.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// The unique GUID of the Text Channel of the Text Channel Participant.
        /// </summary>
        public Guid Text_ChannelID { get; set; }
        /// <summary>
        /// The active status of the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
    }
}
