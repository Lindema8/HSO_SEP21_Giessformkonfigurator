namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertTest : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Grundplatte", "Testcolumn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grundplatte", "Testcolumn");
        }
    }
}
