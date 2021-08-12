namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cupform1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cupform",
                c => new
                    {
                        SAPNr = c.Int(name: "SAP-Nr.", nullable: false),
                        Bezeichnung_RoCon = c.String(maxLength: 255, unicode: false),
                        Cup_Typ = c.String(maxLength: 20, unicode: false),
                        Innendurchmesser = c.Decimal(precision: 10, scale: 2),
                        Toleranz_Innendurchmesser = c.String(maxLength: 10),
                        LK = c.Decimal(precision: 10, scale: 2),
                        Mit_Fuehrungsstift = c.Boolean(nullable: false),
                        Mit_Innengewinde = c.Boolean(nullable: false),
                        Mit_Konusfuehrung = c.Boolean(nullable: false),
                        Mit_Lochfuehrung = c.Boolean(nullable: false),
                        Mit_Innenkern = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SAPNr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cupform");
        }
    }
}
