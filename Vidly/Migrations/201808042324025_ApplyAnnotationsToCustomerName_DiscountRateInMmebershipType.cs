namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCustomerName_DiscountRateInMmebershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "DiscountRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MemberShipTypes", "DurationRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "DurationRate", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MemberShipTypes", "DiscountRate");
        }
    }
}
