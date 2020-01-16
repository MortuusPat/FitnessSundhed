namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsListRemoval : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Execises", "Sets_Id", "dbo.Sets");
            DropForeignKey("dbo.Sets", "Workouts_Id", "dbo.Workouts");
            DropIndex("dbo.Execises", new[] { "Sets_Id" });
            DropIndex("dbo.Sets", new[] { "Workouts_Id" });
            DropColumn("dbo.Execises", "Sets_Id");
            DropColumn("dbo.Sets", "Workouts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sets", "Workouts_Id", c => c.Int());
            AddColumn("dbo.Execises", "Sets_Id", c => c.Int());
            CreateIndex("dbo.Sets", "Workouts_Id");
            CreateIndex("dbo.Execises", "Sets_Id");
            AddForeignKey("dbo.Sets", "Workouts_Id", "dbo.Workouts", "Id");
            AddForeignKey("dbo.Execises", "Sets_Id", "dbo.Sets", "Id");
        }
    }
}
