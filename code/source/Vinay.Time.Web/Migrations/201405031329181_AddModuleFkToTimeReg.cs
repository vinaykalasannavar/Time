namespace Vinay.Time.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddModuleFkToTimeReg : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.TimeRegistrations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Notes = c.String()
                })
                .PrimaryKey(t => t.Id);
            AddColumn("dbo.TimeRegistrations", "ModuleId", c => c.Int(nullable: false));
            CreateIndex("dbo.TimeRegistrations", "ModuleId");
            AddForeignKey("dbo.TimeRegistrations", "ModuleId", "dbo.Modules", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.TimeRegistrations", "ModuleId", "dbo.Modules");
            DropIndex("dbo.TimeRegistrations", new[] { "ModuleId" });
            DropColumn("dbo.TimeRegistrations", "ModuleId");
            DropTable("dbo.TimeRegistrations");
        }
    }
}
