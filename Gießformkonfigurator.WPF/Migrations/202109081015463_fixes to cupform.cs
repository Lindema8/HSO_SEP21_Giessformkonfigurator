namespace Gießformkonfigurator.WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixestocupform : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cupform", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cupform", "Test", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
