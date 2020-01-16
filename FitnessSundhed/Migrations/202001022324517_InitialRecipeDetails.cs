namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialRecipeDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        Measurement = c.String(),
                        Ingredient_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeDetails", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.RecipeDetails", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.RecipeDetails", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeDetails", new[] { "Ingredient_Id" });
            DropTable("dbo.RecipeDetails");
        }
    }
}
