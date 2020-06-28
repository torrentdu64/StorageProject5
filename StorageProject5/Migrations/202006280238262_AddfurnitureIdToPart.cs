namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfurnitureIdToPart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "FurnitureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "FurnitureId");
            AddForeignKey("dbo.Parts", "FurnitureId", "dbo.Furnitures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "FurnitureId", "dbo.Furnitures");
            DropIndex("dbo.Parts", new[] { "FurnitureId" });
            DropColumn("dbo.Parts", "FurnitureId");
        }
    }
}
