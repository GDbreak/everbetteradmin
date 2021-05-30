using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Text Channels.
    /// </summary>
    public class Text_ChannelDetailsResource
    {
        /// <summary>
        /// The unique GUID of the Text Channel. Also identifies the Text Channel in our text chat provider.
        /// </summary>
        public Guid Text_ChannelID { get; set; }
        /// <summary>
        /// The user ID of the user who created the Text Channel.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// Additional information pertaining to the Text Channel.
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
        /// <summary>
        /// A collection of all participants in the Text Channel.
        /// </summary>
        public IEnumerable<Text_Channel_ParticipantResource> Text_Channel_Participants { get; set; }
    }
}
