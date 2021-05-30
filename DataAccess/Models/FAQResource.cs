using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all FAQs.
    /// </summary>
    public class FAQResource
    {
        /// <summary>
        /// The unique ID of the FAQ.
        /// </summary>
        public long FAQID { get; set; }
        /// <summary>
        /// The topic of the FAQ. Used to group FAQ questions together.
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// The question the FAQ is answering.
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// The response to the FAQ question.
        /// </summary>
        public string Response { get; set; }
        /// <summary>
        /// The order the questions should appear in the FAQ.
        /// </summary>
        public int SortOrder { get; set; }
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
