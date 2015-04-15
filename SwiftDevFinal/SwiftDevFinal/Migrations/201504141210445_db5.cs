namespace IdentitySample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectModels", "DateStarted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectModels", "DateStarted", c => c.DateTime(nullable: false));
        }
    }
}
