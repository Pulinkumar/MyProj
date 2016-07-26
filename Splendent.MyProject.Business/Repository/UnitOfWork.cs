using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.DataAccess.EF;
using System;
using System.EnterpriseServices;

namespace Splendent.MyProject.Business.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext dbContext = null;

        public UnitOfWork()
        {
            dbContext = new DatabaseContext();
        }

        IEmployeeRepository employeeRepository = null;
        public IEmployeeRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(dbContext);
                }
                return employeeRepository;
            }
        }

        IDepartmentRepository departmentRepository = null;
        public IDepartmentRepository Departments
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new DepartmentRepository(dbContext);
                }
                return departmentRepository;
            }
        }

        public void BeginTransaction()
        {
            //dbContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public void CommitTransaction()
        {
            //dbContext.Database.Connection.
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }


        #region " Dispose "

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
