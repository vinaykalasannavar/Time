namespace Vinay.Time.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_FKRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkItems", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkItems", "ProjectId");
            AddForeignKey("dbo.WorkItems", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "ProjectId", "dbo.Projects");
            DropIndex("dbo.WorkItems", new[] { "ProjectId" });
            DropColumn("dbo.WorkItems", "ProjectId");
        }
    }
}
