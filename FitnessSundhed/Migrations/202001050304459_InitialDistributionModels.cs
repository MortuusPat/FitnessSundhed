namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDistributionModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanRecipeDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plan_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.Plan_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Plan_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.PlanWorkoutDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plan_Id = c.Int(),
                        Workout_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.Plan_Id)
                .ForeignKey("dbo.Workouts", t => t.Workout_Id)
                .Index(t => t.Plan_Id)
                .Index(t => t.Workout_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanWorkoutDistributions", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.PlanWorkoutDistributions", "Plan_Id", "dbo.Plans");
            DropForeignKey("dbo.PlanRecipeDistributions", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.PlanRecipeDistributions", "Plan_Id", "dbo.Plans");
            DropIndex("dbo.PlanWorkoutDistributions", new[] { "Workout_Id" });
            DropIndex("dbo.PlanWorkoutDistributions", new[] { "Plan_Id" });
            DropIndex("dbo.PlanRecipeDistributions", new[] { "Recipe_Id" });
            DropIndex("dbo.PlanRecipeDistributions", new[] { "Plan_Id" });
            DropTable("dbo.PlanWorkoutDistributions");
            DropTable("dbo.PlanRecipeDistributions");
        }
    }
}
