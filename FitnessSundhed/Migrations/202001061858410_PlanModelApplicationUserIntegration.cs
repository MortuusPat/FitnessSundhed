namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanModelApplicationUserIntegration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Plans", "User_Id");
            AddForeignKey("dbo.Plans", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Plans", new[] { "User_Id" });
            DropColumn("dbo.Plans", "User_Id");
        }
    }
}
