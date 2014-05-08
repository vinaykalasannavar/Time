using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vinay.Time.Web.Models
{
    public class EmployeeWeekSelectionViewModel
    {
        [Display(Name="Employee")]
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<int> Years { get; set; }

        public IEnumerable<int> Weeks { get; set; }

        public Week Week { get; set; }

        public Employee CurrentEmployee { get; set; }

        public EmployeeWeekState State { get; set; }
    }
}