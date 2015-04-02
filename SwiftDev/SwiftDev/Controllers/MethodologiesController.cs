using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SwiftDev.Models
{
    public class MethodologiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Methodologies
        public ActionResult Index()
        {
            return View(db.Methodologies.ToList());
        }

        // GET: Methodologies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Methodology methodology = db.Methodologies.Find(id);
            if (methodology == null)
            {
                return HttpNotFound();
            }
            return View(methodology);
        }

        // GET: Methodologies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Methodologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MethodologyID,MethodologyName")] Methodology methodology)
        {
            if (ModelState.IsValid)
            {
                db.Methodologies.Add(methodology);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(methodology);
        }

        // GET: Methodologies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Methodology methodology = db.Methodologies.Find(id);
            if (methodology == null)
            {
                return HttpNotFound();
            }
            return View(methodology);
        }

        // POST: Methodologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MethodologyID,MethodologyName")] Methodology methodology)
        {
            if (ModelState.IsValid)
            {
                db.Entry(methodology).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(methodology);
        }

        // GET: Methodologies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Methodology methodology = db.Methodologies.Find(id);
            if (methodology == null)
            {
                return HttpNotFound();
            }
            return View(methodology);
        }

        // POST: Methodologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Methodology methodology = db.Methodologies.Find(id);
            db.Methodologies.Remove(methodology);
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
