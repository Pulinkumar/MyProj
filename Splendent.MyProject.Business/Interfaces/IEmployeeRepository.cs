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
        //List<Employee> GetAll();
        //Employee GetByID(int employeeID);
        //List<Employee> SearchByName(string employeeName);
        //bool SaveEmployee(Employee employee);
        //bool DeleteEmployee(int employeeID);

        IEnumerable<Employee> getTopEmployees(int count);
        IEnumerable<Employee> getEmployeeWithSalary(int pageIndex, int pageSize);
    }
}
