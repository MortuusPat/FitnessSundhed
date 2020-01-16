namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExecisesModelToSetModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Execises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Name = c.String(),
                        Reps = c.Int(nullable: false),
                        Note = c.String(),
                        Sets_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sets", t => t.Sets_Id)
                .Index(t => t.Sets_Id);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SetName = c.String(),
                        SetDesc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Workouts", "ExecisesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "ExecisesId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Execises", "Sets_Id", "dbo.Sets");
            DropIndex("dbo.Execises", new[] { "Sets_Id" });
            DropTable("dbo.Sets");
            DropTable("dbo.Execises");
        }
    }
}
