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
using Freelancer.Services;
using Freelancer.Services.Base;

namespace Freelancer.Controllers
{
    public class WorkersController : Controller
    {
        DbContext db = new FreelanceDbContext();
        ServiceBase<Worker> workerService;
        public WorkersController()
        {

            workerService = new Service<Worker>(db);
        }


        // GET: Workers
        public ActionResult Index()
        {
             
            //  int a =  workerService.GetEntityQuery(e => e.Email == User.Identity.Name).Select(e=>e.Id).FirstOrDefault();
            
            return View(workerService.GetEntities());
        }

        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            
            if (!id.HasValue)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = workerService.GetEntity(id.Value);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName")] Worker worker)
        {
            if (ModelState.IsValid)
            {
               worker.Email = User.Identity.Name;
               workerService.AddEntity(worker);
               workerService.SaveChanges();
               return RedirectToAction("Index");
            }

            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = workerService.GetEntity(id.Value);
            
            return View(worker);
        }

        // POST: Workers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName,Rating")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                workerService.UpdateEntity(worker);
                
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker =workerService.GetEntity(id.Value);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = workerService.GetEntity(id);
            workerService.DeleteEntity(worker);
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
