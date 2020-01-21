namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingListModelNewApplicationUserProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingLists", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ShoppingLists", "User_Id");
            AddForeignKey("dbo.ShoppingLists", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingLists", new[] { "User_Id" });
            DropColumn("dbo.ShoppingLists", "User_Id");
        }
    }
}
