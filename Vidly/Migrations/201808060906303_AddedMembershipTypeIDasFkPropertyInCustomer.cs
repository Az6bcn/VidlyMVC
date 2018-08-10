namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipTypeIDasFkPropertyInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemebershipTypeID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MemebershipTypeID");
        }
    }
}
