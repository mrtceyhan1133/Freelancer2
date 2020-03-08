namespace Freelancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.JobAdvertisements", name: "AdvertisementName", newName: "Advertisement Name");
            RenameColumn(table: "dbo.Employers", name: "UserName", newName: "User Name");
            AlterColumn("dbo.JobAdvertisements", "Advertisement Name", c => c.String(nullable: false));
            AlterColumn("dbo.JobAdvertisements", "Explanation", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "User Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Skills", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Workers", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Workers", "Surname", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Workers", "PhoneNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Workers", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Workers", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "Email", c => c.String());
            AlterColumn("dbo.Workers", "UserName", c => c.String());
            AlterColumn("dbo.Workers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Workers", "Surname", c => c.String());
            AlterColumn("dbo.Workers", "Name", c => c.String());
            AlterColumn("dbo.Skills", "Name", c => c.String());
            AlterColumn("dbo.Employers", "Email", c => c.String());
            AlterColumn("dbo.Employers", "User Name", c => c.String());
            AlterColumn("dbo.Employers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Employers", "Surname", c => c.String());
            AlterColumn("dbo.Employers", "Name", c => c.String());
            AlterColumn("dbo.JobAdvertisements", "Explanation", c => c.String());
            AlterColumn("dbo.JobAdvertisements", "Advertisement Name", c => c.String());
            RenameColumn(table: "dbo.Employers", name: "User Name", newName: "UserName");
            RenameColumn(table: "dbo.JobAdvertisements", name: "Advertisement Name", newName: "AdvertisementName");
        }
    }
}
