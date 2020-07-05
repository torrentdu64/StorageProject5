namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeRentalToIntInRentals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.Rentals", new[] { "Rental_Id" });
            DropColumn("dbo.Rentals", "Rental_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Rental_Id", c => c.Int());
            CreateIndex("dbo.Rentals", "Rental_Id");
            AddForeignKey("dbo.Rentals", "Rental_Id", "dbo.Rentals", "Id");
        }
    }
}
