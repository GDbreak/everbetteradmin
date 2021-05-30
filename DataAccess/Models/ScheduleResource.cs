using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{      
    /// <summary>
         /// The resource for all Schedules.
         /// </summary>
    public class ScheduleResource
    {
        /// <summary>
        /// The ID of the schedule.
        /// </summary>
        public long ScheduleID { get; set; }
        /// <summary>
        /// The day of the week for the schedule. Can be 0 - 6.
        /// </summary>
        public int ScheduleDayOfWeek { get; set; }
        /// <summary>
        /// The start time of the schedule. Should be formatted HH:MM:SS.
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// The amount of time in the schedule. Should be formatted HH:MM:SS.
        /// </summary>
        public string AmountOfTime { get; set; }
        /// <summary>
        /// The datetime the schedule starts.
        /// </summary>
        public DateTime ScheduleStartDateTime { get; set; }
        /// <summary>
        /// The datetime the schedule ends. Is irrelevant if the schedule is not recurring.
        /// </summary>
        public DateTime ScheduleEndDateTime { get; set; }
        /// <summary>
        /// The GUID of the user who the schedule is for. This should always be a clinician.
        /// </summary>
        public Guid UsersID { get; set; }
        /// <summary>
        /// Whether the schedule is going to repeat weekly.
        /// </summary>
        public bool Recurring { get; set; }
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
