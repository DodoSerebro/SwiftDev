using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;

namespace SwiftDevFinal.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project/ProjectIndex
        public ActionResult ProjectIndex()
        {
            return View(db.ProjectModels.ToList());
        }

        /*
        // GET: Project/ProjectDetails/5
        public ActionResult ProjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }
        */

        // GET: Project/ProjectCreate
        public ActionResult ProjectCreate()
        {
            return View();
        }

        // POST: Project/ProjectCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCreate([Bind(Include = "ProjectID,ProjectName,ProjectDescription,Company,Methodology,ProjectLeader,DateStarted,DateFinished")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.ProjectModels.Add(projectModel);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ProjectModel record");
                return RedirectToAction("ProjectIndex");
            }

            DisplayErrorMessage();
            return View(projectModel);
        }

        // GET: Project/ProjectEdit/5
        public ActionResult ProjectEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: ProjectProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectEdit([Bind(Include = "ProjectID,ProjectName,ProjectDescription,Company,Methodology,ProjectLeader,DateStarted,DateFinished")] ProjectModel projectModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectModel).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a ProjectModel record");
                return RedirectToAction("ProjectIndex");
            }
            DisplayErrorMessage();
            return View(projectModel);
        }

        // GET: Project/ProjectDelete/5
        public ActionResult ProjectDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectModel projectModel = db.ProjectModels.Find(id);
            if (projectModel == null)
            {
                return HttpNotFound();
            }
            return View(projectModel);
        }

        // POST: Project/ProjectDelete/5
        [HttpPost, ActionName("ProjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectDeleteConfirmed(int id)
        {
            ProjectModel projectModel = db.ProjectModels.Find(id);
            db.ProjectModels.Remove(projectModel);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ProjectModel record");
            return RedirectToAction("ProjectIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
