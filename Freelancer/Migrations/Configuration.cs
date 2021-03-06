namespace Freelancer.Migrations
{
    using Freelancer.Controllers;
    using Freelancer.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Freelancer.Context.FreelanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Freelancer.Context.FreelanceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
          
            List<Worker> workerList = new List<Worker>()
            {
                new Worker()
                {
                    Id=1,
                    Name="Ya�mur",
                    Surname="Atici",
                    PhoneNumber="12345",
                    UserName="Ya�mu�",
                    Rating = 5,
                    WorkerSkills=new List<WorkerSkill>(),
                     Email="yagmur@atici.com"
                },
                new Worker()
                {
                    Id=2,
                    Name="Murat",
                    Surname="Ceyhan",
                    PhoneNumber="123456",
                    UserName="Mur�ik",
                    Rating = 5,
                    WorkerSkills=new List<WorkerSkill>(),
                    Email="murcik@123.com"
                },
                new Worker()
                {
                    Id=3,
                    Name="Alev",
                    Surname="Y�lmaz",
                    PhoneNumber="112525456",
                    UserName="Ate�",
                    Rating = 3.8,
                    WorkerSkills=new List<WorkerSkill>(),
                    Email="alev@yilmaz.com"
                },
            };
            List<Employer> employerList = new List<Employer>()
            {
                new Employer()
                {
                    Id=1,
                    Name="�a��l",
                    PhoneNumber="1234123",
                    Surname="Alsa�",
                    UserName="Angeleo",
                    JobAdvertisements = new List<JobAdvertisement>(),
                    Email="cagil@alsac.com"
                    
                },
                new Employer()
                {
                    Id=2,
                    Name="Erkan",
                    PhoneNumber="123232234123",
                    Surname="Hoca",
                    UserName="EHoca",
                    JobAdvertisements = new List<JobAdvertisement>(),
                    Email="erkan@hoca.com"
                },
                new Employer()
                {
                    Id=3,
                    Name="Ceku",
                    PhoneNumber="443232",
                    Surname="Bal�m",
                    UserName="Cb123",
                    JobAdvertisements = new List<JobAdvertisement>(),
                    Email="ceku@balim.com"
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
                context.Workers.AddOrUpdate(m => m.Name,
                    new Worker
                    {
                        Name = worker.Name,
                        PhoneNumber = worker.PhoneNumber,
                        Rating = worker.Rating,
                        Surname = worker.Surname,
                        UserName = worker.UserName,
                        WorkerSkills = worker.WorkerSkills,
                        Email=worker.Email

                    }
                );
            }
            foreach (Employer employer in employerList)
            {
                context.Employers.AddOrUpdate(e => e.Name,
                   new Employer()
                   {
                       Id = employer.Id,
                       Name = employer.Name,
                       PhoneNumber = employer.PhoneNumber,
                       Surname = employer.Surname,
                       UserName = employer.UserName,
                       Email=employer.Email,
                       JobAdvertisements = employer.JobAdvertisements
                   }
                   );
            }
            foreach (Skill skill in skillList)
            {
                context.Skills.AddOrUpdate(m => m.Name,
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
                context.Categories.AddOrUpdate(m => m.Name,
                    new Category
                    {
                        Name = category.Name,
                        CategoryJobAdvertisements = category.CategoryJobAdvertisements
                    }
                );
            }
            //foreach (JobAdvertisement jobAdvertisement in jobAdvertisementList)
            //{
            //    context.JobAdvertisements.AddOrUpdate(m => m.AdvertisementName,
            //        new JobAdvertisement
            //        {

            //            AdvertisementName = jobAdvertisement.AdvertisementName,
            //            CategoryJobAdvertisements = jobAdvertisement.CategoryJobAdvertisements,
            //            SkillJobAdvertisements = jobAdvertisement.SkillJobAdvertisements,
            //            Explanation = jobAdvertisement.Explanation,
            //            EmployerId = jobAdvertisement.EmployerId,
            //            Employer = jobAdvertisement.Employer
            //        }
            //    );
            //}





        }
    }
}
