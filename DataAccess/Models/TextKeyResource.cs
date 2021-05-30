using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for keys required to access the text provider.
    /// </summary>
    public class TextKeyResource
    {
        /// <summary>
        /// The publish key for the text provider.
        /// </summary>
        public string PublishKey { get; set; }
        /// <summary>
        /// The subscribe key for the text provider.
        /// </summary>
        public string SubscribeKey { get; set; }
       
    }
}
