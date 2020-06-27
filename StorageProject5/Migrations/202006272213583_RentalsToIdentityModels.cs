namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsToIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rentals");
        }
    }
}
