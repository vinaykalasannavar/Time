using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClock.Web.Models;

namespace eClock.Web.Controllers
{
    public class ProjectController : Controller
    {
        private eClockWebContext db = new eClockWebContext();

        // GET: /Project/
        public ActionResult Index()
        {
            var projects = db.Projects
                .Include(p => p.Modules)
                .ToList();
            return View(projects);
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,State")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,State")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: /Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult NewModuleRow()
        {
            return PartialView("_NewModuleRow");
        }

        [HttpPost]
        public ActionResult SaveModule([Bind(Include = "Id,Name,ProjectId")] Module module)
        {
            JsonResult returnValue;
            try
            {
                if (module.Id == 0)
                {
                    var newModule = db.Modules.Add(module);
                    int newId = db.SaveChanges();
                    returnValue = Json(
                        new
                        {
                            Success = true,
                            NewModuleId = newModule.Id
                        });
                }
                else
                {
                    db.Entry(module).State = EntityState.Modified;
                    db.SaveChanges();
                    returnValue = Json(new { Success = true });
                }
            }
            catch (Exception exc)
            {
                returnValue = Json(new { Error = exc.Message });
            }

            return returnValue;
        }

        // POST: /Project/DeleteModule/5
        [HttpPost, ActionName("DeleteModule")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteModuleConfirmed(int moduleId)
        {
            JsonResult returnValue;
            bool noReferencesToModuleExist = db.Modules.Any(m => m.Id == moduleId);
            var module = db.Modules.Find(moduleId);
            if (noReferencesToModuleExist)
            {
                db.Modules.Remove(module);
                db.SaveChanges();
                returnValue = Json(new { Success = true });
            }
            else
            {
                returnValue = Json(new
                {
                    Error = string.Format(
                        "Can't delete module {0}, people have logged time against it.", module.Name)
                });
            }

            return returnValue;
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
