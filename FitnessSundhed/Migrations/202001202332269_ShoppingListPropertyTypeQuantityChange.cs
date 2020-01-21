namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingListPropertyTypeQuantityChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingLists", "Quantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingLists", "Quantity", c => c.Single(nullable: false));
        }
    }
}
