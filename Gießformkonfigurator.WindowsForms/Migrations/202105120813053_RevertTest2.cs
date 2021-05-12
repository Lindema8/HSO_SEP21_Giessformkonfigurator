namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertTest2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Grundplatte", "Testfeld");
            DropColumn("dbo.Grundplatte", "Testcolumn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grundplatte", "Testcolumn", c => c.String());
            AddColumn("dbo.Grundplatte", "Testfeld", c => c.String());
        }
    }
}
