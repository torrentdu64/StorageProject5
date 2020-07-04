namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoolCheckboxIsRentedToFurniture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Furnitures", "IsRented", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Furnitures", "IsRented");
        }
    }
}
