using System.Net;
using System.Web.Mvc;
using Splendent.MyProject.Entities;
using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.Infrastructure.IOC;
using Microsoft.Practices.Unity;
using Splendent.MyProject.DataAccess.EF;
using Splendent.MyProject.Business.Repository;

namespace Splendent.MyProject.Web.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController()
            : this(IoC.Container.Resolve<IEmployeeRepository>())
        {
        }

        public EmployeeController(IEmployeeRepository employeeBL)
        {
            this._employeeRepository = employeeBL;
        }

        public ActionResult Index()
        {
            return View(_employeeRepository.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.SingleOrDefault(e => e.EmployeeID == id);  //_employeeRepository.Get((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Add(employee);
                _employeeRepository.Complete();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.Get((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,FirstName,LastName,Address1,Address2,City,State,Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                _employeeRepository.Complete();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeRepository.Get((int)id); //_employeeRepository.GetByID((int)id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var emp = _employeeRepository.Get(id);
            _employeeRepository.Remove(emp);
            _employeeRepository.Complete();
            //_employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    employeeBL = null;
            //}
            base.Dispose(disposing);
        }
    }
}
