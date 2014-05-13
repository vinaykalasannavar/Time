using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class RegisteredHours
    {
        public int Id { get; set; }

        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }
        public double Total { get; set; }
    }
}
