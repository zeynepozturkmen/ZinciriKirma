namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_19 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CalendarEvents", newName: "CalenderEvents");
            AddColumn("dbo.Chain", "color", c => c.String());
            AlterColumn("dbo.Chain", "StartingDate", c => c.String());
            AlterColumn("dbo.Chain", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Chain", "StartingDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Chain", "color");
            RenameTable(name: "dbo.CalenderEvents", newName: "CalendarEvents");
        }
    }
}
