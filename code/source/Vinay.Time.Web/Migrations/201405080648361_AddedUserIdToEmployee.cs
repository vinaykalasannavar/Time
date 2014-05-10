namespace Vinay.Time.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
