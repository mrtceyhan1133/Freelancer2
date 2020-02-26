using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Freelancer.Context;
using Freelancer.Entities;

namespace Freelancer.Controllers
{
    public class HireController : Controller
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: Hire
        public ActionResult Index()
        {
            return View(db.JobAdvertisements.ToList());
        }

        // GET: Hire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(jobAdvertisement);
        }

        // GET: Hire/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hire/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdvertisementName,Explanation,UserId")] JobAdvertisement jobAdvertisement)
        {
            if (ModelState.IsValid)
            {
                db.JobAdvertisements.Add(jobAdvertisement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobAdvertisement);
        }

        // GET: Hire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(jobAdvertisement);
        }

        // POST: Hire/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdvertisementName,Explanation,UserId")] JobAdvertisement jobAdvertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobAdvertisement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobAdvertisement);
        }

        // GET: Hire/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(jobAdvertisement);
        }

        // POST: Hire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobAdvertisement jobAdvertisement = db.JobAdvertisements.Find(id);
            db.JobAdvertisements.Remove(jobAdvertisement);
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
