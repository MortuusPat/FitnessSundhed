namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRecipesNIngredients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Intruction = c.String(),
                        EnergyKJ = c.Int(nullable: false),
                        EnergyCals = c.Int(nullable: false),
                        Protein = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Sugar = c.Double(nullable: false),
                        Fiber = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
