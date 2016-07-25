using Splendent.MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MyProject.Business.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        ////Employee Specific Functions
        IEnumerable<Employee> getTopEmployees(int count);
        IEnumerable<Employee> getEmployeeWithSalary(int pageIndex, int pageSize);
    }
}
