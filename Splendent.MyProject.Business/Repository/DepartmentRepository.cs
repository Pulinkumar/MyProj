using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.DataAccess.EF;
using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.Business.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context)
            : base(context)
        {
        }

        public DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
