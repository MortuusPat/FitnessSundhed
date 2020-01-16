namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlanModelDayPropertyStringToDayOfWeekType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plans", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plans", "Day", c => c.String());
        }
    }
}
