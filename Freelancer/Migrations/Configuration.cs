namespace Freelancer.Migrations
{
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

            List<User> userList = new List<User>()
            {
                new User()
                {
                    Id=1,
                    Name="Yaðmur",
                    Surname="Atici",
                    PhoneNumber="12345",
                    UserName="Yaðmuþ",
                    Rating = 5,
                    UserSkills=new List<UserSkill>(),
                    JobAdvertisements=new List<JobAdvertisement>()
                },
                new User()
                {
                    Id=2,
                    Name="Murat",
                    Surname="Ceyhan",
                    PhoneNumber="123456",
                    UserName="Murçik",
                    Rating = 5,
                    UserSkills=new List<UserSkill>(),
                    JobAdvertisements=new List<JobAdvertisement>()
                },
                new User()
                {
                    Id=3,
                    Name="Alev",
                    Surname="Yýlmaz",
                    PhoneNumber="112525456",
                    UserName="Ateþ",
                    Rating = 3.8,
                    UserSkills=new List<UserSkill>(),
                    JobAdvertisements=new List<JobAdvertisement>()
                },
            };
            List<Skill> skillList = new List<Skill>()
            {
                new Skill()
                {
                    Id=1,
                    Name="C#",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    UserSkills=new List<UserSkill>()
                },
                new Skill()
                {
                    Id=2,
                    Name="Java",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    UserSkills=new List<UserSkill>()
                },
                new Skill()
                {
                    Id=3,
                    Name="Phyton",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    UserSkills=new List<UserSkill>()
                },
                new Skill()
                {
                    Id=4,
                    Name=".NET",
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    UserSkills=new List<UserSkill>()
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
                    UserId = 2,
                    AdvertisementName="WebSite",
                    Explanation="aasdasdasd",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()
                    
                },
                new JobAdvertisement()
                {
                    Id=2,
                    UserId = 1,
                    AdvertisementName="Game",
                    Explanation="Flappy Bird",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>(),
                    
                    
                    
                },
                new JobAdvertisement()
                {
                    Id=3,
                    UserId = 3,
                    AdvertisementName="Design",
                    Explanation="asdasdfffffffffff",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()
                    
                    
                },
                new JobAdvertisement()
                {
                    Id=4,
                    UserId = 3,
                    AdvertisementName="Design222",
                    Explanation="asdasdffffffffffasdf",
                    CategoryJobAdvertisements=new List<CategoryJobAdvertisement>(),
                    SkillJobAdvertisements=new List<SkillJobAdvertisement>()
                    
                    
                },
            };
            List<UserSkill> userSkillsList = new List<UserSkill>()
            {
                new UserSkill()
                {
                    Id=1,
                    UserId=1,
                    SkillId=2
                },
                new UserSkill()
                {
                    Id=2,
                    UserId=1,
                    SkillId=1
                },
                new UserSkill()
                {
                    Id=3,
                    UserId=2,
                    SkillId=1
                },
                new UserSkill()
                {
                    Id=4,
                    UserId=2,
                    SkillId=3
                },
                new UserSkill()
                {
                    Id=5,
                    UserId=3,
                    SkillId=4
                },
                new UserSkill()
                {
                    Id=6,
                    UserId=3,
                    SkillId=1
                },
                new UserSkill()
                {
                    Id=7,
                    UserId=3,
                    SkillId=2
                }
            };
            foreach(var user in userList)
            {
                List<UserSkill> userSkills = userSkillsList.Where(e => e.UserId == user.Id).ToList();
                foreach (var userSkill in userSkills.ToList())
                {
                    user.UserSkills.Add(userSkill);
                }
            }
            foreach (var user in userList)
            {
                List<JobAdvertisement> jobAdvertisements = jobAdvertisementList.Where(e => e.UserId == user.Id).ToList();
                foreach (var jobAdvertisement in jobAdvertisements.ToList())
                {
                    user.JobAdvertisements.Add(jobAdvertisement);
                }
            }
            foreach (var skill in skillList)
            {
                List<UserSkill> userSkills = userSkillsList.Where(e => e.SkillId == skill.Id).ToList();
                foreach (var userSkill in userSkills.ToList())
                {
                    skill.UserSkills.Add(userSkill);
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
            foreach (User user in userList)
            {
                context.Users.AddOrUpdate(m => m.Name,
                    new User
                    {
                        Name = user.Name,
                        JobAdvertisements = user.JobAdvertisements,
                        PhoneNumber = user.PhoneNumber,
                        Rating = user.Rating,
                        Surname = user.Surname,
                        UserName = user.UserName,
                        UserSkills = user.UserSkills
                    }
                );
            }
            foreach (Skill skill in skillList)
            {
                context.Skills.AddOrUpdate(m => m.Name,
                    new Skill
                    {
                        Name=skill.Name,
                        SkillJobAdvertisements=skill.SkillJobAdvertisements,
                        UserSkills=skill.UserSkills
                    }
                );
            }
            foreach (Category category in categoryList)
            {
                context.Categories.AddOrUpdate(m => m.Name,
                    new Category
                    {
                        Name = category.Name,
                        CategoryJobAdvertisements=category.CategoryJobAdvertisements
                    }
                );
            }
            foreach (JobAdvertisement jobAdvertisement in jobAdvertisementList)
            {
                context.JobAdvertisements.AddOrUpdate(m => m.AdvertisementName,
                    new JobAdvertisement
                    {
                        
                        AdvertisementName = jobAdvertisement.AdvertisementName,
                        CategoryJobAdvertisements=jobAdvertisement.CategoryJobAdvertisements,
                        SkillJobAdvertisements = jobAdvertisement.SkillJobAdvertisements,
                        Explanation=jobAdvertisement.Explanation,
                        UserId=jobAdvertisement.UserId,
                        User=jobAdvertisement.User
                    }
                );
            }





        }
    }
}
