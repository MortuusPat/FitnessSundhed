namespace FitnessSundhed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsDataAnnontationImplemtation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Execises", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Execises", "Note", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Recipes", "Intruction", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.RecipeDetails", "Measurement", c => c.String(nullable: false));
            AlterColumn("dbo.Sets", "SetName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Sets", "SetDesc", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sets", "SetDesc", c => c.String());
            AlterColumn("dbo.Sets", "SetName", c => c.String());
            AlterColumn("dbo.RecipeDetails", "Measurement", c => c.String());
            AlterColumn("dbo.Recipes", "Intruction", c => c.String());
            AlterColumn("dbo.Recipes", "Name", c => c.String());
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
            AlterColumn("dbo.Execises", "Note", c => c.String());
            AlterColumn("dbo.Execises", "Name", c => c.String());
        }
    }
}
