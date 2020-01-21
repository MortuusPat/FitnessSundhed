namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipesModelUpdateNewPropertyIsChecked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "IsChecked");
        }
    }
}
