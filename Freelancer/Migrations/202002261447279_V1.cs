namespace Freelancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.UserSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Users",
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
            DropForeignKey("dbo.UserSkills", "UserId", "dbo.Users");
            DropForeignKey("dbo.JobAdvertisements", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillJobAdvertisements", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillJobAdvertisements", "JobAdvertisementId", "dbo.JobAdvertisements");
            DropForeignKey("dbo.CategoryJobAdvertisements", "JobAdvertisementId", "dbo.JobAdvertisements");
            DropForeignKey("dbo.CategoryJobAdvertisements", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserSkills", new[] { "SkillId" });
            DropIndex("dbo.UserSkills", new[] { "UserId" });
            DropIndex("dbo.SkillJobAdvertisements", new[] { "JobAdvertisementId" });
            DropIndex("dbo.SkillJobAdvertisements", new[] { "SkillId" });
            DropIndex("dbo.JobAdvertisements", new[] { "UserId" });
            DropIndex("dbo.CategoryJobAdvertisements", new[] { "JobAdvertisementId" });
            DropIndex("dbo.CategoryJobAdvertisements", new[] { "CategoryId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserSkills");
            DropTable("dbo.Skills");
            DropTable("dbo.SkillJobAdvertisements");
            DropTable("dbo.JobAdvertisements");
            DropTable("dbo.CategoryJobAdvertisements");
            DropTable("dbo.Categories");
        }
    }
}
