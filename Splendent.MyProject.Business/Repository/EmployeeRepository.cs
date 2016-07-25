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
        public EmployeeRepository(EmployeeContext context)
            : base(context)
        {
        }

        public IEnumerable<Employee> getTopEmployees(int count)
        {
            return EmployeeContext.Employees.OrderBy(c => c.FirstName).Take(count).ToList();
        }

        public IEnumerable<Employee> getEmployeeWithSalary(int pageIndex, int pageSize)
        {
            return EmployeeContext.Employees.OrderBy(c => c.FirstName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize).ToList();
        }

        public EmployeeContext EmployeeContext
        {
            get { return Context as EmployeeContext; }
        }

        //private EmployeeContext _context = new EmployeeContext();

        //#region IEmployeeRepository Members

        //public List<Employee> GetAll()
        //{
        //    try
        //    {
        //        return _context.Employees.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public Employee GetByID(int employeeID)
        //{
        //    return _context.Employees.Find(employeeID);
        //}

        //public List<Employee> SearchByName(string employeeName)
        //{
        //    return _context.Employees.Where(e => e.EmployeeName.ToLower().StartsWith(employeeName.ToLower())).ToList();
        //}

        //public bool SaveEmployee(Employee employee)
        //{
        //    try
        //    {
        //        if (employee.EmployeeID == 0)
        //        {
        //            _context.Employees.Add(employee);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            _context.Entry(employee).State = EntityState.Modified;
        //            _context.SaveChanges();
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public bool DeleteEmployee(int employeeID)
        //{
        //    try
        //    {
        //        Employee employee = _context.Employees.Find(employeeID);
        //        _context.Employees.Remove(employee);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion

    }
}
