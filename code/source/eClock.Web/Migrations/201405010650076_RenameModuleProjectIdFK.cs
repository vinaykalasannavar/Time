namespace eClock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameModuleProjectIdFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Modules", "projectId", "dbo.Projects");
            DropIndex("dbo.Modules", new[] { "projectId" });
            AlterColumn("dbo.Modules", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Modules", "ProjectId");
            AddForeignKey("dbo.Modules", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Modules", new[] { "ProjectId" });
            AlterColumn("dbo.Modules", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Modules", "projectId");
            AddForeignKey("dbo.Modules", "projectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
