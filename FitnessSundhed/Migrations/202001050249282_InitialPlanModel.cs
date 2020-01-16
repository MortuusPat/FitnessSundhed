namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialPlanModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Plans");
        }
    }
}
