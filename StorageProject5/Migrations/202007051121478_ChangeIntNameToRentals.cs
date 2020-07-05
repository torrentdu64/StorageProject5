namespace StorageProject5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntNameToRentals : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "Name", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "Name", c => c.String());
        }
    }
}
