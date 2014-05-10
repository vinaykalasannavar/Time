using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public string Password { get; set; }
        public ApplicationUser User { get; set; }
    }
}
