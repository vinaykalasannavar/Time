using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vinay.Time.Web.Models
{
    public class TimeWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // t d
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TimeWebContext() : base("name=TimeWebContext")
        {
        }

        public System.Data.Entity.DbSet<Vinay.Time.Web.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Vinay.Time.Web.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Vinay.Time.Web.Models.Module> Modules { get; set; }

        public DbSet<Week> Weeks { get; set; }

        public DbSet<EmployeeWeek> EmployeeWeeks { get; set; }

        public DbSet<WorkItem> WorkItems { get; set; }

        public DbSet<TimeRegistration> TimeRegistrations { get; set; }

        public DbSet<RegisteredHours> RegisteredHours { get; set; }

    }
}
