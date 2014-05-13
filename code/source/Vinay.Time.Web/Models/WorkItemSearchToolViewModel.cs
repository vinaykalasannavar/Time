using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class WorkItemSearchToolViewModel
    {
        public WorkItemFinderViewModel WorkItemFinderVM { get; set; }
        public RecentRegistrationsViewModel RecentRegistrationsVM { get; set; }
        public OftenRepeatedRegistrationsViewModel OftenRepeatedRegistrationsVM { get; set; }
    }
}
