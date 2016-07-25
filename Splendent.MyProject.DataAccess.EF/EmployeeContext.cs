using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.DataAccess.EF
{
    public class EmployeeContext : BaseDbContext<EmployeeContext>
    {
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().ToTable("tblEmployee");
            base.OnModelCreating(modelBuilder);
        }
    }
}
