namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutSetExecisesForeignKeysImplement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Execises", "SetsId", c => c.Int(nullable: false));
            AddColumn("dbo.Sets", "WorkoutsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sets", "WorkoutsId");
            DropColumn("dbo.Execises", "SetsId");
        }
    }
}
