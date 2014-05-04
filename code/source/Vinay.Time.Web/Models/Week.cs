using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class Week
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
