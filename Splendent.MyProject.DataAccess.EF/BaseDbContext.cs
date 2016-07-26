using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.DataAccess.EF
{
    public class BaseDbContext<TContext> : DbContext where TContext : DbContext
    {
        static BaseDbContext()
        {
            Database.SetInitializer<TContext>(null);
        }
        protected BaseDbContext()
            : base("name=DBString")
        {
        }

    }
}
