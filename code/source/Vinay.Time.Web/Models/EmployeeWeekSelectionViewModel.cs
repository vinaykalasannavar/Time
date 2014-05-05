using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vinay.Time.Web.Models
{
    public class EmployeeWeekSelectionViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<int> Years { get; set; }
    }
}