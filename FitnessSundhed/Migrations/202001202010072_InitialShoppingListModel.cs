namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialShoppingListModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        Measurement = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        IngredientId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId_Id)
                .Index(t => t.IngredientId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingLists", "IngredientId_Id", "dbo.Ingredients");
            DropIndex("dbo.ShoppingLists", new[] { "IngredientId_Id" });
            DropTable("dbo.ShoppingLists");
        }
    }
}
