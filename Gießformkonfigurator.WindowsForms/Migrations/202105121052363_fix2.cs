namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bolzen", "hallotest", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bolzen", "hallotest");
        }
    }
}
