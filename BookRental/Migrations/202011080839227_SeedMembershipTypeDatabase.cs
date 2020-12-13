namespace BookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipTypeDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO [dbo].[MembershipTypes](Name,SignUpFee,ChargeRateSixMonth,ChargeRateOneMonth) VALUES('Pay per Rental',0,50,25)");
            Sql("Insert INTO [dbo].[MembershipTypes](Name,SignUpFee,ChargeRateSixMonth,ChargeRateOneMonth) VALUES('Member',150,20,10)");
            Sql("Insert INTO [dbo].[MembershipTypes](Name,SignUpFee,ChargeRateSixMonth,ChargeRateOneMonth) VALUES('SuperAdmin',0,0,0)");

        }
        
        public override void Down()
        {
        }
    }
}
