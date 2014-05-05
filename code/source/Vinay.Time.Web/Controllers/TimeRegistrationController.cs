using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vinay.Time.Web.Models;
using System.Globalization;

namespace Vinay.Time.Web.Controllers
{
    public class TimeRegistrationController : Controller
    {
        private TimeWebContext db = new TimeWebContext();

        // GET: /TimeRegistration/
        public ActionResult Index()
        {
            //TestMethod();
            EmployeeWeekSelectionViewModel weekSelectionVM = new EmployeeWeekSelectionViewModel();
            weekSelectionVM.Employees = db.Employees.ToList();
            weekSelectionVM.Years = YearsList();
            return View(weekSelectionVM);

            //var timeregistrations = db.TimeRegistrations.Include(t => t.EmployeeWeek).Include(t => t.Module).Include(t => t.WorkItem);
            //return View(timeregistrations.ToList());
        }

        private IEnumerable<int> YearsList()
        {
            List<int> years = new List<int>();
            string yearsConfigString = System.Configuration.ConfigurationManager.AppSettings["TimeRegYearRange"];
            if (yearsConfigString != null)
            {
                var yearsArray = yearsConfigString.Split('-');
                int startYear = Convert.ToInt32(yearsArray[0]);
                int endYear = Convert.ToInt32(yearsArray[1]);
                for (int year = startYear; year < endYear; year++)
                {
                    years.Add(year);
                }
            }

            return years;
        }

        // GET: /TimeRegistration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRegistration timeregistration = db.TimeRegistrations.Find(id);
            if (timeregistration == null)
            {
                return HttpNotFound();
            }
            return View(timeregistration);
        }

        // GET: /TimeRegistration/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeWeekId = new SelectList(db.EmployeeWeeks, "Id", "Id");
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Name");
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Title");
            return View();
        }

        // POST: /TimeRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkItemId,ModuleId,EmployeeWeekId,Notes")] TimeRegistration timeregistration)
        {
            if (ModelState.IsValid)
            {
                db.TimeRegistrations.Add(timeregistration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeWeekId = new SelectList(db.EmployeeWeeks, "Id", "Id", timeregistration.EmployeeWeekId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Name", timeregistration.ModuleId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Title", timeregistration.WorkItemId);
            return View(timeregistration);
        }

        // GET: /TimeRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRegistration timeregistration = db.TimeRegistrations.Find(id);
            if (timeregistration == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeWeekId = new SelectList(db.EmployeeWeeks, "Id", "Id", timeregistration.EmployeeWeekId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Name", timeregistration.ModuleId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Title", timeregistration.WorkItemId);
            return View(timeregistration);
        }

        // POST: /TimeRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkItemId,ModuleId,EmployeeWeekId,Notes")] TimeRegistration timeregistration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeregistration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeWeekId = new SelectList(db.EmployeeWeeks, "Id", "Id", timeregistration.EmployeeWeekId);
            ViewBag.ModuleId = new SelectList(db.Modules, "Id", "Name", timeregistration.ModuleId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Title", timeregistration.WorkItemId);
            return View(timeregistration);
        }

        // GET: /TimeRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRegistration timeregistration = db.TimeRegistrations.Find(id);
            if (timeregistration == null)
            {
                return HttpNotFound();
            }
            return View(timeregistration);
        }

        // POST: /TimeRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeRegistration timeregistration = db.TimeRegistrations.Find(id);
            db.TimeRegistrations.Remove(timeregistration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void TestMethod()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            int weekNo;
            DateTime date = new DateTime(2014, 01, 05);
            weekNo = dfi.Calendar.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);


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
