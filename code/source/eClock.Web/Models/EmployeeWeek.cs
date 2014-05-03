using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class EmployeeWeek
    {
        public int Id { get; set; }

        [ForeignKey("Week")]
        public int WeekId { get; set; }
        public virtual Week Week { get; set; }
        
        public EmployeeWeekState State { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<TimeRegistration> TimeRegistrations { get; set; }
    }
}