namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Bolzen", "hallotest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bolzen", "hallotest", c => c.String());
        }
    }
}
