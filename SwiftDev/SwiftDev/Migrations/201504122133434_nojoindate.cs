namespace SwiftDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nojoindate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 100));
            DropColumn("dbo.AspNetUsers", "JoinDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Description");
        }
    }
}
