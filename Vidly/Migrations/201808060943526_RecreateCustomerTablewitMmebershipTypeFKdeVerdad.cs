namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateCustomerTablewitMmebershipTypeFKdeVerdad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewLetter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MemberShipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MemberShipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Int(nullable: false),
                        DurationInMonths = c.Int(nullable: false),
                        DiscountRate = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.MemberShipTypes");
            DropTable("dbo.Customers");
        }
    }
}
