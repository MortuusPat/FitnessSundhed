namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlanModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Day", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Day");
        }
    }
}
