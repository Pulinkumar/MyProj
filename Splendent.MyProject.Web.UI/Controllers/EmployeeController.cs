using System.Net;
using System.Web.Mvc;
using Splendent.MyProject.Entities;
using Splendent.MyProject.Business.Interfaces;
using Splendent.MyProject.Infrastructure.IOC;
using Microsoft.Practices.Unity;
using Splendent.MyProject.Business.Repository;

namespace Splendent.MyProject.Web.UI.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IUnitOfWork unitofWork;
        public EmployeeController()
            : this(IoC.Container.Resolve<IUnitOfWork>())
        {
        }

        public EmployeeController(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        public ActionResult Index()
        {
            return View(unitofWork.Employees.GetAll());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = unitofWork.Employees.SingleOrDefault(e => e.EmployeeID == id);
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
                unitofWork.Employees.Add(employee);
                unitofWork.SaveChanges();
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
            Employee employee = unitofWork.Employees.Get((int)id);
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
                unitofWork.Employees.Update(employee);
                unitofWork.SaveChanges();
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
            Employee employee = unitofWork.Employees.Get((int)id);
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
            var emp = unitofWork.Employees.Get(id);
            unitofWork.Employees.Remove(emp);
            unitofWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitofWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
