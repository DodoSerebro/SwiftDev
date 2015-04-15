namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectModels",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(maxLength: 255),
                        ProjectDescription = c.String(maxLength: 255),
                        Company = c.String(maxLength: 30),
                        Methodology = c.String(maxLength: 10),
                        ProjectLeader = c.String(maxLength: 256),
                        DateStarted = c.DateTime(nullable: false),
                        DateFinished = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProjectID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectModels");
        }
    }
}
