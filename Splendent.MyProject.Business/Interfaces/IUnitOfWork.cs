using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        void SaveChanges();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
