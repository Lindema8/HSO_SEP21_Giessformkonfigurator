namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grundplatte", "Testfeld", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grundplatte", "Testfeld");
        }
    }
}
