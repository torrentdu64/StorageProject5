namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCollectionToRentals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Rental_Id", c => c.Int());
            AddColumn("dbo.Furnitures", "Rental_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Rental_Id");
            CreateIndex("dbo.Furnitures", "Rental_Id");
            AddForeignKey("dbo.Customers", "Rental_Id", "dbo.Rentals", "Id");
            AddForeignKey("dbo.Furnitures", "Rental_Id", "dbo.Rentals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Furnitures", "Rental_Id", "dbo.Rentals");
            DropForeignKey("dbo.Customers", "Rental_Id", "dbo.Rentals");
            DropIndex("dbo.Furnitures", new[] { "Rental_Id" });
            DropIndex("dbo.Customers", new[] { "Rental_Id" });
            DropColumn("dbo.Furnitures", "Rental_Id");
            DropColumn("dbo.Customers", "Rental_Id");
        }
    }
}
