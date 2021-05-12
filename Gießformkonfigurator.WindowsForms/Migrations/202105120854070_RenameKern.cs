namespace Gießformkonfigurator.WindowsForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameKern : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Innenkern", newName: "Kern");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Kern", newName: "Innenkern");
        }
    }
}
