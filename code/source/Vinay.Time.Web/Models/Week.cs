using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Vinay.Time.Web.Models
{
    public class Week
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        [Display(Name="From")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime StartDate { get; set; }
        [Display(Name = "To")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
