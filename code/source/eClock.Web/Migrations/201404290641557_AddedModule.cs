namespace eClock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModule : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        projectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.projectId, cascadeDelete: true)
                .Index(t => t.projectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "projectId", "dbo.Projects");
            DropIndex("dbo.Modules", new[] { "projectId" });
            DropTable("dbo.Modules");
        }
    }
}
