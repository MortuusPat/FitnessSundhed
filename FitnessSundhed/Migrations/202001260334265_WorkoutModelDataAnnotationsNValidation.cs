namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutModelDataAnnotationsNValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Workouts", "Author", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Workouts", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "Equipment", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Workouts", "Targets", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Targets", c => c.String());
            AlterColumn("dbo.Workouts", "Equipment", c => c.String());
            AlterColumn("dbo.Workouts", "Description", c => c.String());
            AlterColumn("dbo.Workouts", "Author", c => c.String());
            AlterColumn("dbo.Workouts", "Name", c => c.String());
        }
    }
}
