namespace Freelancer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workers", "Rating", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workers", "Rating", c => c.Double(nullable: false));
        }
    }
}
