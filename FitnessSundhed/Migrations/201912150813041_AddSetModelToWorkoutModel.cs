namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetModelToWorkoutModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "Workouts_Id", c => c.Int());
            CreateIndex("dbo.Sets", "Workouts_Id");
            AddForeignKey("dbo.Sets", "Workouts_Id", "dbo.Workouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "Workouts_Id", "dbo.Workouts");
            DropIndex("dbo.Sets", new[] { "Workouts_Id" });
            DropColumn("dbo.Sets", "Workouts_Id");
        }
    }
}
