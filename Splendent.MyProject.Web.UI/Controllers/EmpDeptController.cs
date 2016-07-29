using System.Net;
using System.Web.Mvc;
using Splendent.MyProject.Entities;
using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.Infrastructure.IOC;
using Microsoft.Practices.Unity;
using Splendent.MyProject.Web.UI.Models;
using System;

namespace Splendent.MyProject.Web.UI.Controllers
{
    public class EmpDeptController : Controller
    {
        private readonly IUnitOfWork unitofWork;
        public EmpDeptController()
            : this(IoC.Container.Resolve<IUnitOfWork>())
        {
        }

        public EmpDeptController(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        // GET: EmpDept
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeDepartmentViewModel employeeDepartmentViewModel)
        {
            try
            {
                unitofWork.BeginTransaction();

                unitofWork.Departments.Add(employeeDepartmentViewModel.Department);
                unitofWork.Employees.Add(employeeDepartmentViewModel.Employee);
                unitofWork.SaveChanges();

                unitofWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                unitofWork.RollbackTransaction();
            }
            return View();
        }
    }
}