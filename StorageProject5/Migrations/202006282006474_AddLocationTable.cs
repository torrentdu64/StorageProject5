namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Parts", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "LocationId");
            AddForeignKey("dbo.Parts", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "LocationId", "dbo.Locations");
            DropIndex("dbo.Parts", new[] { "LocationId" });
            DropColumn("dbo.Parts", "LocationId");
            DropTable("dbo.Locations");
        }
    }
}
