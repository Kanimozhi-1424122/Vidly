namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMemberShipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes SET Name='Pay As you Go' WHERE Id=1");
            Sql("UPDATE MemberShipTypes SET Name='Quterly' WHERE Id=2");
            Sql("UPDATE MemberShipTypes SET Name='Half-yearly' WHERE Id=3");
            Sql("UPDATE MemberShipTypes SET Name='Annual' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
