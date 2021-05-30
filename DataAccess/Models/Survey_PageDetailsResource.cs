
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The detailed resource for all Survey Pages.
    /// </summary>
    public class Survey_PageDetailsResource
    {
        /// <summary>
        /// The ID of the survey page.
        /// </summary>
        public int Survey_PageID { get; set; }
        /// <summary>
        /// The header text of the survey page.
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// The sort order for the survey pages. Used to determine the order pages are displayed to the user.
        /// </summary>
        public int SortOrder { get; set; }
        /// <summary>
        /// The active status for the object.
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// The date and time the object was created.
        /// </summary>
        public DateTime CreatedDateTime { get; set; }
        /// <summary>
        /// The survey questions that appear in the survey page.
        /// </summary>
        public IEnumerable<Survey_QuestionResource> Survey_Questions { get; set; }
    }
}
