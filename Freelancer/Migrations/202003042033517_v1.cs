namespace Freelancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryJobAdvertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        JobAdvertisementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.JobAdvertisements", t => t.JobAdvertisementId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.JobAdvertisementId);
            
            CreateTable(
                "dbo.JobAdvertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdvertisementName = c.String(),
                        Explanation = c.String(),
                        EmployerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.EmployerId, cascadeDelete: true)
                .Index(t => t.EmployerId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkillJobAdvertisements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillId = c.Int(nullable: false),
                        JobAdvertisementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobAdvertisements", t => t.JobAdvertisementId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.JobAdvertisementId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkerSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Workers", t => t.WorkerId, cascadeDelete: true)
                .Index(t => t.WorkerId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerSkills", "WorkerId", "dbo.Workers");
            DropForeignKey("dbo.WorkerSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillJobAdvertisements", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillJobAdvertisements", "JobAdvertisementId", "dbo.JobAdvertisements");
            DropForeignKey("dbo.JobAdvertisements", "EmployerId", "dbo.Employers");
            DropForeignKey("dbo.CategoryJobAdvertisements", "JobAdvertisementId", "dbo.JobAdvertisements");
            DropForeignKey("dbo.CategoryJobAdvertisements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WorkerSkills", new[] { "SkillId" });
            DropIndex("dbo.WorkerSkills", new[] { "WorkerId" });
            DropIndex("dbo.SkillJobAdvertisements", new[] { "JobAdvertisementId" });
            DropIndex("dbo.SkillJobAdvertisements", new[] { "SkillId" });
            DropIndex("dbo.JobAdvertisements", new[] { "EmployerId" });
            DropIndex("dbo.CategoryJobAdvertisements", new[] { "JobAdvertisementId" });
            DropIndex("dbo.CategoryJobAdvertisements", new[] { "CategoryId" });
            DropTable("dbo.Workers");
            DropTable("dbo.WorkerSkills");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillJobAdvertisements");
            DropTable("dbo.Employers");
            DropTable("dbo.JobAdvertisements");
            DropTable("dbo.CategoryJobAdvertisements");
            DropTable("dbo.Categories");
        }
    }
}
