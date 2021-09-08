namespace Gießformkonfigurator.WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cupformattributesadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cupform", "Test", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Cupform", "Konus_Innen_Max", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Cupform", "Konus_Innen_Min", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Cupform", "Konus_Innen_Winkel", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cupform", "Test");
            DropColumn("dbo.Cupform", "Konus_Innen_Max");
            DropColumn("dbo.Cupform", "Konus_Innen_Min");
            DropColumn("dbo.Cupform", "Konus_Innen_Winkel");
        }
    }
}
