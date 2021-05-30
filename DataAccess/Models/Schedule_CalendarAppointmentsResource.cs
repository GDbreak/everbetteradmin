using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// The resource for all Schedule Calendar Appointments. Formatted for the application's calendar view.
    /// </summary>
    public class Schedule_CalendarAppointmentResource
    {
        /// <summary>
        /// The ID of the schedule calendar appointment.
        /// </summary>
        public int Schedule_CalendarAppointmentID { get; set; }
        /// <summary>
        /// The start datetime of the schedule.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The end datetime of the schedule.
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
