namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "MovieGenre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MovieGenre");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
