namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAutoCreatedMembershipTypeFkCustomerTable : DbMigration
    {
        public override void Up()
        {

            Sql("Drop table Customers");
            //Sql("Drop table MemberShipTypes ");
        }
        
        public override void Down()
        {
        }
    }
}
