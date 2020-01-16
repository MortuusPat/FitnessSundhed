namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExecisesModelToWorkoutModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "ExecisesId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "ExecisesId");
        }
    }
}
