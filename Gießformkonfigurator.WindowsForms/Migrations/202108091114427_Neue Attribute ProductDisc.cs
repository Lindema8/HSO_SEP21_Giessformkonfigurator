namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeueAttributeProductDisc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProduktDisc", "Lk1Durchmesser", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk1Bohrungen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk1Gewinde", c => c.String());
            AddColumn("dbo.ProduktDisc", "Lk2Durchmesser", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk2Bohrungen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk2Gewinde", c => c.String());
            AddColumn("dbo.ProduktDisc", "Lk3Durchmesser", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk3Bohrungen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProduktDisc", "Lk3Gewinde", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProduktDisc", "Lk3Gewinde");
            DropColumn("dbo.ProduktDisc", "Lk3Bohrungen");
            DropColumn("dbo.ProduktDisc", "Lk3Durchmesser");
            DropColumn("dbo.ProduktDisc", "Lk2Gewinde");
            DropColumn("dbo.ProduktDisc", "Lk2Bohrungen");
            DropColumn("dbo.ProduktDisc", "Lk2Durchmesser");
            DropColumn("dbo.ProduktDisc", "Lk1Gewinde");
            DropColumn("dbo.ProduktDisc", "Lk1Bohrungen");
            DropColumn("dbo.ProduktDisc", "Lk1Durchmesser");
        }
    }
}
