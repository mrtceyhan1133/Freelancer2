using Freelancer.Context;
using Freelancer.Entities;
using Freelancer.Models.ViewModels;
using Freelancer.Services;
using Freelancer.Services.Base;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Freelancer.Controllers
{
    public class JobAdvertisementsController : Controller
    {
        DbContext db = new FreelanceDbContext();
        ServiceBase<JobAdvertisement> jobAdvertisementService;
        public JobAdvertisementsController()
        {
            jobAdvertisementService = new Service<JobAdvertisement>(db);
        }

        // GET: JobAdvertisements
        public ActionResult Index()
        {
            //var jobAdvertisements2 = jobAdvertisementService.GetEntityQuery().Include(e => e.EmployerId).ToList();
            var jobAdvertisements = jobAdvertisementService.GetEntities().Where(e => e.Employer != null).ToList();

            return View(jobAdvertisements);
        }
        

        // GET: JobAdvertisements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = jobAdvertisementService.GetEntity(id.Value);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(jobAdvertisement);
        }

        // GET: JobAdvertisements/Create
        public ActionResult Create()
        {
            //ViewBag.EmployerId = new SelectList(db.Employers, "Id", "Name");
            return View();
        }

        // POST: JobAdvertisements/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdvertisementName,Explanation,EmployerId")] JobAdvertisement jobAdvertisement)
        {
            if (ModelState.IsValid)
            {
                jobAdvertisementService.AddEntity(jobAdvertisement);
                return RedirectToAction("Index");
            }

            //ViewBag.EmployerId = new SelectList(db.Employers, "Id", "Name", jobAdvertisement.EmployerId);
            return View(jobAdvertisement);
        }

        // GET: JobAdvertisements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = jobAdvertisementService.GetEntity(id.Value);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EmployerId = new SelectList(db.Employers, "Id", "Name", jobAdvertisement.EmployerId);
            return View(jobAdvertisement);
        }

        // POST: JobAdvertisements/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdvertisementName,Explanation,EmployerId")] JobAdvertisement jobAdvertisement)
        {
            if (ModelState.IsValid)
            {
                jobAdvertisementService.UpdateEntity(jobAdvertisement);
                return RedirectToAction("Index");
            }
            //ViewBag.EmployerId = new SelectList(db.Employers, "Id", "Name", jobAdvertisement.EmployerId);
            return View(jobAdvertisement);
        }

        // GET: JobAdvertisements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobAdvertisement jobAdvertisement = jobAdvertisementService.GetEntity(id.Value);
            if (jobAdvertisement == null)
            {
                return HttpNotFound();
            }
            return View(jobAdvertisement);
        }

        // POST: JobAdvertisements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobAdvertisement jobAdvertisement = jobAdvertisementService.GetEntity(id);
            jobAdvertisementService.DeleteEntity(jobAdvertisement);
            return RedirectToAction("Index");
        }  
        public ActionResult List(JobAdvertisementViewModel jobAdvertisementViewModel)
        {
            if (jobAdvertisementViewModel == null)
                jobAdvertisementViewModel = new JobAdvertisementViewModel();
            var query = jobAdvertisementService.GetEntityQuery();
            if (jobAdvertisementViewModel.AdvertisementName != null)
                query = query.Where(e => e.AdvertisementName.ToLower().Contains(jobAdvertisementViewModel.AdvertisementName.ToLower()));
            if (jobAdvertisementViewModel.EmployerName != null)
                query = query.Where(e => e.Employer.Name.ToLower().Contains(jobAdvertisementViewModel.EmployerName.ToLower()));
            if (jobAdvertisementViewModel.EmployerUserName != null)
                query = query.Where(e => e.Employer.UserName.ToLower().Contains(jobAdvertisementViewModel.EmployerUserName.ToLower()));
            if (jobAdvertisementViewModel.Explanation != null)
                query = query.Where(e => e.Explanation.ToLower().Contains(jobAdvertisementViewModel.Explanation.ToLower()));
            //if (jobAdvertisementViewModel.Category != null)
            //    query = query..FindAll(e => e.CategoryJobAdvertisements.FindAll(e=>e.Category.Name==jobAdvertisementViewModel.Category));
            
            jobAdvertisementViewModel.JobAdvertisements = query.ToList();
            return View(jobAdvertisementViewModel);
        }
    }
}
