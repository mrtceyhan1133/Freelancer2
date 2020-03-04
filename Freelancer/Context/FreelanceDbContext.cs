using Freelancer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Freelancer.Context
{
    public class FreelanceDbContext : DbContext
    {
        public FreelanceDbContext() : base("FreelanceDbContext")
        {

        }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<WorkerSkill> WorkerSkills { get; set; }
        public virtual DbSet<SkillJobAdvertisement> SkillJobAdvertisements { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<JobAdvertisement> JobAdvertisements { get; set; }
        public virtual DbSet<CategoryJobAdvertisement> CategoryJobAdvertisements { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<vwUser>();
        }
    }
}