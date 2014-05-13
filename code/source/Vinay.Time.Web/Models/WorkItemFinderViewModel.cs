using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class WorkItemFinderViewModel
    {
        public bool ProjectFilterRequired { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }


        public bool ModuleFilterRequired { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        public bool AssignedEmployeeFilterRequired { get; set; }
        [ForeignKey("Employee")]
        public int AssignedEmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public bool StateFilterRequired { get; set; }
        public virtual ProjectState State { get; set; }

        public bool NumberOrTitleFilterRequired { get; set; }
        public int WorkItemNumberId { get; set; }
        public string WorkItemTitle { get; set; }

        public IEnumerable<WorkItem> WorkItems { get; set; }
    }
}
