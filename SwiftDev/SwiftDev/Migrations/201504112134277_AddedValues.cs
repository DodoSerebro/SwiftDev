namespace SwiftDev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValues : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.String(nullable: false, maxLength: 128),
                        ProjectName = c.String(nullable: false),
                        ProjectDescription = c.String(nullable: false),
                        Company = c.String(nullable: false),
                        Methodology = c.String(nullable: false),
                        ProjectLeader = c.String(nullable: false),
                        DateStarted = c.DateTime(nullable: false),
                        DateFinished = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Methodology",
                c => new
                    {
                        MethodologyID = c.String(nullable: false, maxLength: 128),
                        MethodologyName = c.String(),
                    })
                .PrimaryKey(t => t.MethodologyID);
            
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AspNetUsers", "JoinDate");
        }
    }
}
