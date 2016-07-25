using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.DataAccess.EF
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DatabaseContext()
            : base("name=SplendentDBString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
