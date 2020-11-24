﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPropertieReleaseYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseYear", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseYear");
        }
    }
}
