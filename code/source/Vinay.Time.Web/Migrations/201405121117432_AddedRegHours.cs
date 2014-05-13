namespace Vinay.Time.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRegHours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisteredHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monday = c.Double(nullable: false),
                        Tuesday = c.Double(nullable: false),
                        Wednesday = c.Double(nullable: false),
                        Thursday = c.Double(nullable: false),
                        Friday = c.Double(nullable: false),
                        Saturday = c.Double(nullable: false),
                        Sunday = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TimeRegistrations", "RegisteredHoursId", c => c.Int(nullable: false));
            CreateIndex("dbo.TimeRegistrations", "RegisteredHoursId");
            AddForeignKey("dbo.TimeRegistrations", "RegisteredHoursId", "dbo.RegisteredHours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeRegistrations", "RegisteredHoursId", "dbo.RegisteredHours");
            DropIndex("dbo.TimeRegistrations", new[] { "RegisteredHoursId" });
            DropColumn("dbo.TimeRegistrations", "RegisteredHoursId");
            DropTable("dbo.RegisteredHours");
        }
    }
}
