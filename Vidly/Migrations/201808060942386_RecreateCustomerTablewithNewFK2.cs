namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateCustomerTablewithNewFK2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MemberShipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.MemberShipTypes");
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewLetter = c.Boolean(nullable: false),
                        MemebershipTypeID = c.Int(nullable: false),
                        Birthdate = c.DateTime(),
                        MembershipType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MemberShipTypes", "Id");
        }
    }
}
