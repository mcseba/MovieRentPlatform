namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullsToBirthdayProp : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = NULL WHERE Id = 1");
            Sql("UPDATE Customers SET Birthday = NULL WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
