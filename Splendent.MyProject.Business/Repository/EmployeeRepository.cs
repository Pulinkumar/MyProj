using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.DataAccess.EF;
using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Splendent.MyProject.Business.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context)
            : base(context)
        {
        }

        public IEnumerable<Employee> getTopEmployees(int count)
        {
            return DbContext.Employee.OrderBy(c => c.FirstName).Take(count).ToList();
        }

        public IEnumerable<Employee> getEmployeeWithSalary(int pageIndex, int pageSize)
        {
            return DbContext.Employee.OrderBy(c => c.FirstName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public DatabaseContext DbContext
        {
            get { return Context as DatabaseContext; }
        }

    }
}
