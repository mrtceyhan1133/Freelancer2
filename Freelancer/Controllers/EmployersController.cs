using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Freelancer.Context;
using Freelancer.Entities;
using Freelancer.Services;
using Freelancer.Services.Base;

namespace Freelancer.Controllers
{
    public class EmployersController : Controller
    {
        DbContext db = new FreelanceDbContext();
        ServiceBase<Employer> employerService;
        public EmployersController()
        {
            employerService = new Service<Employer>(db);
        }

        // GET: Employers
        public ActionResult Index()
        {
            return View(employerService.GetEntities());
        }

        // GET: Employers/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = employerService.GetEntity(id.Value);
            return View(employer);
        }

        //// GET: Employers/Create
        [NonAction]
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Employers/Create
        //// Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        //// daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [NonAction]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                employer.Email = User.Identity.Name;
                employerService.AddEntity(employer);
                employerService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employer);
        }

        //// GET: Employers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employer employer = employerService.GetEntity(id.Value);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //// POST: Employers/Edit/5
        //// Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        //// daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                employerService.UpdateEntity(employer);
                employerService.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        //// GET: Employers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employer employer = employerService.GetEntity(id.Value);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        //// POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer =employerService.GetEntity(id);
            employerService.DeleteEntity(employer);
            employerService.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}



    }
}
