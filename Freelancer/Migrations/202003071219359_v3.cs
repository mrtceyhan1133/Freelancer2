namespace Freelancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "Email", c => c.String());
            AddColumn("dbo.Workers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workers", "Email");
            DropColumn("dbo.Employers", "Email");
        }
    }
}
