﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class Module
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        //public virtual ICollection<TimeRegistration> TimeRegistrations { get; set; }
    }
}
