using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClock.Web.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + LastName;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}