namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeueNullAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Max", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Min", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Winkel", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Hoehe", c => c.Decimal(precision: 10, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Einlegeplatte", "Konus_Hoehe", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Winkel", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Min", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Einlegeplatte", "Konus_Außen_Max", c => c.Decimal(nullable: false, precision: 10, scale: 2));
        }
    }
}
