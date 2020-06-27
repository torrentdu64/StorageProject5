namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FurnitureModelAndRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rentals", "FurnitureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "FurnitureId");
            AddForeignKey("dbo.Rentals", "FurnitureId", "dbo.Furnitures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "FurnitureId", "dbo.Furnitures");
            DropIndex("dbo.Rentals", new[] { "FurnitureId" });
            DropColumn("dbo.Rentals", "FurnitureId");
            DropTable("dbo.Furnitures");
        }
    }
}
