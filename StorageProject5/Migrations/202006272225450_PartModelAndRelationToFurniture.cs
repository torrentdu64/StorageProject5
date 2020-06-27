namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartModelAndRelationToFurniture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Furnitures", "PartId", c => c.Int(nullable: false));
            CreateIndex("dbo.Furnitures", "PartId");
            AddForeignKey("dbo.Furnitures", "PartId", "dbo.Parts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Furnitures", "PartId", "dbo.Parts");
            DropIndex("dbo.Furnitures", new[] { "PartId" });
            DropColumn("dbo.Furnitures", "PartId");
            DropTable("dbo.Parts");
        }
    }
}
