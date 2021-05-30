using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Survey Questions.
    /// </summary>
    public class Survey_QuestionResource
    {
        /// <summary>
        /// The ID for the survey question.
        /// </summary>
        public int Survey_QuestionID { get; set; }
        /// <summary>
        /// Placeholder text for the survey question.
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// Whether the question requires a response.
        /// </summary>
        public bool IsRequired { get; set; }
        /// <summary>
        /// Whether the question has multiple pre-defined responses. Cannot be true if isFreeField or isDateField are true.
        /// </summary>
        public bool IsMultipleChoice { get; set; }
        /// <summary>
        /// Whether the question is a free text field. Cannot be true if isMultipleChoice or isDateField are true.
        /// </summary>
        public bool IsFreeField { get; set; }
        /// <summary>
        /// Whether the question is a date field. Cannot be true if isFreeField or isMultipeChoice are true.
        /// </summary>
        public bool IsDateField { get; set; }
        /// <summary>
        /// Additional details describing the question.
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// The survey page the question belongs to. This is null it is not assigned to a page.
        /// </summary>
        public int? Survey_PageID { get; set; }
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
