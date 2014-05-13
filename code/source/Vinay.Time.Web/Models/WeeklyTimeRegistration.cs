using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vinay.Time.Web.Models
{
    public class WeeklyTimeRegistrationViewModel
    {
        public EmployeeWeekSelectionViewModel EmployeeWeekSelectionVM { get; set; }
        public WorkItemSearchToolViewModel WorkItemSearchToolVM { get; set; }
        public IEnumerable<Vinay.Time.Web.Models.TimeRegistration> TimeRegistrations { get; set; }
    }
}