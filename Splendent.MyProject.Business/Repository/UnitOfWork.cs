using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.DataAccess.EF;
using System;
using System.Data.Entity;
using System.EnterpriseServices;

namespace Splendent.MyProject.Business.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext dbContext = null;
        private DbContextTransaction dbTran;

        public UnitOfWork()
        {
            dbContext = new DatabaseContext();
        }

        #region " Entities "

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

        #endregion

        #region " DB Transaction "

        public void BeginTransaction()
        {
            dbTran = dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dbTran.Commit();
        }

        public void RollbackTransaction()
        {
            dbTran.Rollback();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        #endregion

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
