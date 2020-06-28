namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTheFieldPartToFourniture : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Furnitures", "PartId", "dbo.Parts");
            DropIndex("dbo.Furnitures", new[] { "PartId" });
            DropColumn("dbo.Furnitures", "PartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Furnitures", "PartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Furnitures", "PartId");
            AddForeignKey("dbo.Furnitures", "PartId", "dbo.Parts", "Id", cascadeDelete: true);
        }
    }
}
