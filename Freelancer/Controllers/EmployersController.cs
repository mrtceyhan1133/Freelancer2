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

namespace Freelancer.Controllers
{
    public class EmployersController : Controller
    {
        private FreelanceDbContext db = new FreelanceDbContext();

        // GET: Employers
        public ActionResult Index()
        {
            return View(db.Employers.ToList());
        }

        // GET: Employers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employers/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Employers.Add(employer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employer);
        }

        // GET: Employers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employers/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,PhoneNumber,UserName")] Employer employer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employer);
        }

        // GET: Employers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = db.Employers.Find(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // POST: Employers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employer employer = db.Employers.Find(id);
            db.Employers.Remove(employer);
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
        public void x()
        {
            List<Worker> workerList = new List<Worker>()
            {
                new Worker()
                {
                    Id=1,
                    Name="Yağmur",
                    Surname="Atici",
                    PhoneNumber="12345",
                    UserName="Yağmuş",
                    Rating = 5,
                    WorkerSkills=new List<WorkerSkill>()
                },
                new Worker()
                {
                    Id=2,
                    Name="Murat",
                    Surname="Ceyhan",
                    PhoneNumber="123456",
                    UserName="Murçik",
                    Rating = 5,
                    WorkerSkills=new List<WorkerSkill>()
                },
                new Worker()
                {
                    Id=3,
                    Name="Alev",
                    Surname="Yılmaz",
                    PhoneNumber="112525456",
                    UserName="Ateş",
                    Rating = 3.8,
                    WorkerSkills=new List<WorkerSkill>(),
                },
            };
            List<Employer> employerList = new List<Employer>()
            {
                new Employer()
                {
                    Id=1,
                    Name="Çağıl",
                    PhoneNumber="1234123",
                    Surname="Alsaç",
                    UserName="Angeleo",
                    JobAdvertisements = new List<JobAdvertisement>()
                },
                new Employer()
                {
                    Id=2,
                    Name="Erkan",
                    PhoneNumber="123232234123",
                    Surname="Hoca",
                    UserName="EHoca",
                    JobAdvertisements = new List<JobAdvertisement>()
                },
                new Employer()
                {
                    Id=3,
                    Name="Ceku",
                    PhoneNumber="443232",
                    Surname="Balım",
                    UserName="Cb123",
                    JobAdvertisements = new List<JobAdvertisement>()
                }

            };
            List<Skill> skillList = new List<Skill>()
            {
                new Skill()
                {
                    Id=1,
                    Name="C#",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    WorkerSkills=new List<WorkerSkill>()
                },
                new Skill()
                {
                    Id=2,
                    Name="Java",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    WorkerSkills=new List<WorkerSkill>()
                },
                new Skill()
                {
                    Id=3,
                    Name="Phyton",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    WorkerSkills=new List<WorkerSkill>()
                },
                new Skill()
                {
                    Id=4,
                    Name=".NET",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    WorkerSkills=new List<WorkerSkill>()
                },
            };
            List<Category> categoryList = new List<Category>()
            {
                new Category()
                {
                    Id=1,
                    Name="Web Development",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>()
                },
                new Category()
                {
                    Id=2,
                    Name="Artifical Intelligence",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>()
                },
                new Category()
                {
                    Id=3,
                    Name="Game Development",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>()
                }
            };
            List<JobAdvertisement> jobAdvertisementList = new List<JobAdvertisement>()
            {
                new JobAdvertisement()
                {
                    Id=1,
                    EmployerId = 2,
                    AdvertisementName="WebSite",
                    Explanation="aasdasdasd",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()

                },
                new JobAdvertisement()
                {
                    Id=2,
                    EmployerId = 1,
                    AdvertisementName="Game",
                    Explanation="Flappy Bird",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),



                },
                new JobAdvertisement()
                {
                    Id=3,
                    EmployerId = 3,
                    AdvertisementName="Design",
                    Explanation="asdasdfffffffffff",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()


                },
                new JobAdvertisement()
                {
                    Id=4,
                    EmployerId = 3,
                    AdvertisementName="Design222",
                    Explanation="asdasdffffffffffasdf",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()


                },
            };
            List<WorkerSkill> userSkillsList = new List<WorkerSkill>()
            {
                new WorkerSkill()
                {
                    Id=1,
                    WorkerId=1,
                    SkillId=2
                },
                new WorkerSkill()
                {
                    Id=2,
                    WorkerId=1,
                    SkillId=1
                },
                new WorkerSkill()
                {
                    Id=3,
                    WorkerId=2,
                    SkillId=1
                },
                new WorkerSkill()
                {
                    Id=4,
                    WorkerId=2,
                    SkillId=3
                },
                new WorkerSkill()
                {
                    Id=5,
                    WorkerId=3,
                    SkillId=4
                },
                new WorkerSkill()
                {
                    Id=6,
                    WorkerId=3,
                    SkillId=1
                },
                new WorkerSkill()
                {
                    Id=7,
                    WorkerId=3,
                    SkillId=2
                }
            };
            foreach (var worker in workerList)
            {
                List<WorkerSkill> userSkills = userSkillsList.Where(e => e.WorkerId == worker.Id).ToList();
                foreach (var userSkill in userSkills.ToList())
                {
                    worker.WorkerSkills.Add(userSkill);
                }
            }
            foreach (var employer in employerList)
            {
                List<JobAdvertisement> jobAdvertisements = jobAdvertisementList.Where(e => e.EmployerId == employer.Id).ToList();
                foreach (var jobAdvertisement in jobAdvertisements)
                {
                    employer.JobAdvertisements.Add(jobAdvertisement);
                }
            }
            foreach (var skill in skillList)
            {
                List<WorkerSkill> userSkills = userSkillsList.Where(e => e.SkillId == skill.Id).ToList();
                foreach (var userSkill in userSkills)
                {
                    skill.WorkerSkills.Add(userSkill);
                }
            }
            List<SkillJobAdvertisement> skillJobAdvertisementsList = new List<SkillJobAdvertisement>()
            {
                new SkillJobAdvertisement()
                {
                    Id=1,
                    JobAdvertisementId=1,
                    SkillId=1
                },
                new SkillJobAdvertisement()
                {
                    Id=2,
                    JobAdvertisementId=1,
                    SkillId=2
                },
                new SkillJobAdvertisement()
                {
                    Id=3,
                    JobAdvertisementId=2,
                    SkillId=2
                },  new SkillJobAdvertisement()
                {
                    Id=4,
                    JobAdvertisementId=2,
                    SkillId=3
                },  new SkillJobAdvertisement()
                {
                    Id=5,
                    JobAdvertisementId=2,
                    SkillId=4
                },new SkillJobAdvertisement()
                {
                    Id=6,
                    JobAdvertisementId=3,
                    SkillId=1
                },new SkillJobAdvertisement()
                {
                    Id=7,
                    JobAdvertisementId=3,
                    SkillId=2
                },new SkillJobAdvertisement()
                {
                    Id=8,
                    JobAdvertisementId=3,
                    SkillId=3
                },new SkillJobAdvertisement()
                {
                    Id=9,
                    JobAdvertisementId=3,
                    SkillId=4
                },


            };
            foreach (var skill in skillList)
            {
                List<SkillJobAdvertisement> skillJobAdvertisements = skillJobAdvertisementsList.Where(e => e.SkillId == skill.Id).ToList();
                foreach (var skillJobAdvertisement in skillJobAdvertisements.ToList())
                {
                    skill.SkillJobAdvertisements.Add(skillJobAdvertisement);
                }
            }
            foreach (var jobAdvertisement in jobAdvertisementList)
            {
                List<SkillJobAdvertisement> skillJobAdvertisements = skillJobAdvertisementsList.Where(e => e.JobAdvertisementId == jobAdvertisement.Id).ToList();
                foreach (var skillJobAdvertisement in skillJobAdvertisements.ToList())
                {
                    jobAdvertisement.SkillJobAdvertisements.Add(skillJobAdvertisement);
                }
            }
            List<CategoryJobAdvertisement> categoryJobAdvertisementList = new List<CategoryJobAdvertisement>() {
                new CategoryJobAdvertisement()
                {
                    Id=1,
                    CategoryId=1,
                    JobAdvertisementId=1
                },
                new CategoryJobAdvertisement()
                {
                    Id=2,
                    CategoryId=1,
                    JobAdvertisementId=2
                },   new CategoryJobAdvertisement()
                {
                    Id=3,
                    CategoryId=2,
                    JobAdvertisementId=2
                },   new CategoryJobAdvertisement()
                {
                    Id=4,
                    CategoryId=2,
                    JobAdvertisementId=3
                },   new CategoryJobAdvertisement()
                {
                    Id=5,
                    CategoryId=3,
                    JobAdvertisementId=1
                },   new CategoryJobAdvertisement()
                {
                    Id=6,
                    CategoryId=3,
                    JobAdvertisementId=2
                },   new CategoryJobAdvertisement()
                {
                    Id=7,
                    CategoryId=3,
                    JobAdvertisementId=3
                }
            };
            foreach (var category in categoryList)
            {
                List<CategoryJobAdvertisement> categoryJobAdvertisements = categoryJobAdvertisementList.Where(e => e.CategoryId == category.Id).ToList();
                foreach (var categoryJobAdvertisement in categoryJobAdvertisements.ToList())
                {
                    category.CategoryJobAdvertisements.Add(categoryJobAdvertisement);
                }
            }
            foreach (var jobAdvertisement in jobAdvertisementList)
            {
                List<CategoryJobAdvertisement> categoryJobAdvertisements = categoryJobAdvertisementList.Where(e => e.JobAdvertisementId == jobAdvertisement.Id).ToList();
                foreach (var categoryJobAdvertisement in categoryJobAdvertisements.ToList())
                {
                    jobAdvertisement.CategoryJobAdvertisements.Add(categoryJobAdvertisement);
                }
            }

            // context update:
            foreach (Worker worker in workerList)
            {
                db.Workers.AddOrUpdate(m => m.Name,
                    new Worker
                    {
                        Name = worker.Name,
                        PhoneNumber = worker.PhoneNumber,
                        Rating = worker.Rating,
                        Surname = worker.Surname,
                        UserName = worker.UserName,
                        WorkerSkills = worker.WorkerSkills
                    }
                );
            }
            foreach (Employer employer in employerList)
            {
                db.Employers.AddOrUpdate(e => e.Name,
                   new Employer()
                   {
                       Id = employer.Id,
                       Name = employer.Name,
                       PhoneNumber = employer.PhoneNumber,
                       Surname = employer.Surname,
                       UserName = employer.UserName,
                       JobAdvertisements = employer.JobAdvertisements
                   }
                   );
            }
            foreach (Skill skill in skillList)
            {
                db.Skills.AddOrUpdate(m => m.Name,
                    new Skill
                    {
                        Name = skill.Name,
                        SkillJobAdvertisements = skill.SkillJobAdvertisements,
                        WorkerSkills = skill.WorkerSkills
                    }
                );
            }
            foreach (Category category in categoryList)
            {
                db.Categories.AddOrUpdate(m => m.Name,
                    new Category
                    {
                        Name = category.Name,
                        CategoryJobAdvertisements = category.CategoryJobAdvertisements
                    }
                );
            }
            foreach (JobAdvertisement jobAdvertisement in jobAdvertisementList)
            {
                db.JobAdvertisements.AddOrUpdate(m => m.AdvertisementName,
                    new JobAdvertisement
                    {

                        AdvertisementName = jobAdvertisement.AdvertisementName,
                        CategoryJobAdvertisements = jobAdvertisement.CategoryJobAdvertisements,
                        SkillJobAdvertisements = jobAdvertisement.SkillJobAdvertisements,
                        Explanation = jobAdvertisement.Explanation,
                        EmployerId = jobAdvertisement.EmployerId,
                        Employer = jobAdvertisement.Employer
                    }
                );
            }
        }
    }
}
