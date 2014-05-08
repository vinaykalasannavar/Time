namespace Vinay.Time.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weeks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Number = c.Int(nullable: false),
                    Year = c.Int(nullable: false),
                    StartDate = c.DateTime(),
                    EndDate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weeks");
        }
    }
}
