namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedTheInFournitureModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Furnitures", "PartId", "dbo.Parts");
            DropIndex("dbo.Furnitures", new[] { "PartId" });
            AlterColumn("dbo.Furnitures", "PartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Furnitures", "PartId");
            AddForeignKey("dbo.Furnitures", "PartId", "dbo.Parts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Furnitures", "PartId", "dbo.Parts");
            DropIndex("dbo.Furnitures", new[] { "PartId" });
            AlterColumn("dbo.Furnitures", "PartId", c => c.Int());
            CreateIndex("dbo.Furnitures", "PartId");
            AddForeignKey("dbo.Furnitures", "PartId", "dbo.Parts", "Id");
        }
    }
}
