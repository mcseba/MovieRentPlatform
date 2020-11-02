namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthdayValueToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '10/04/1998' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
