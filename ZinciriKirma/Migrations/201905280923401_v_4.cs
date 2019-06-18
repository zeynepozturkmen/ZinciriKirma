namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CalenderEvents", newName: "CalendarEvents");
            DropPrimaryKey("dbo.CalendarEvents");
            AlterColumn("dbo.Chain", "StartingDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.CalendarEvents", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CalendarEvents", "id");
            DropColumn("dbo.Chain", "color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chain", "color", c => c.String());
            DropPrimaryKey("dbo.CalendarEvents");
            AlterColumn("dbo.CalendarEvents", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Chain", "EndDate", c => c.String());
            AlterColumn("dbo.Chain", "StartingDate", c => c.String());
            AddPrimaryKey("dbo.CalendarEvents", "id");
            RenameTable(name: "dbo.CalendarEvents", newName: "CalenderEvents");
        }
    }
}
