namespace eClock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedModulesFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Modules", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "Name");
            DropColumn("dbo.Projects", "Name");
        }
    }
}
