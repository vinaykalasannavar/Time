using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vinay.Time.Web.Models;

namespace Vinay.Time.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
            //: this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
            AccountController = new AccountController();
        }

        protected AccountController AccountController { get; private set; }
        private TimeWebContext db = new TimeWebContext();

        // GET: /Employee/
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            EmployeeViewModel employeeVM = new EmployeeViewModel
            {
                Employee = new Employee {  },
                User = new ApplicationUser { }
            };

            return View(employeeVM);
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Employee,User,Password")] EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                var result = await AccountController.UserManager.CreateAsync(employeeVM.User, employeeVM.Password);

                if (result.Succeeded)
                {
                    employeeVM.Employee.UserId = employeeVM.User.Id;

                    db.Employees.Add(employeeVM.Employee);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    AccountController.AddErrors(result);
                }
            }

            return View(employeeVM.Employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            var user = AccountController.UserManager.FindById(employee.UserId);

            EmployeeViewModel vm = new EmployeeViewModel
            {
                Employee = employee,
                User = user
            };

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee")] EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeVM.Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeVM);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
