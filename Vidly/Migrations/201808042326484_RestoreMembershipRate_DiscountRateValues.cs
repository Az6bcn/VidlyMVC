namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestoreMembershipRate_DiscountRateValues : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set DiscountRate = 0 where Id = 1 ");
            Sql("Update MembershipTypes set DiscountRate = 10 where Id = 2 ");
            Sql("Update MembershipTypes set DiscountRate = 15 where Id = 3 ");
            Sql("Update MembershipTypes set DiscountRate = 20 where Id = 4 ");
        }
        
        public override void Down()
        {
        }
    }
}
