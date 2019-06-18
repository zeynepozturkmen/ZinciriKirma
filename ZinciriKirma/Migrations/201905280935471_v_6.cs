namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CalenderEvents", newName: "CalendarEvents");
            AlterColumn("dbo.Chain", "StartingDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Chain", "color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chain", "color", c => c.String());
            AlterColumn("dbo.Chain", "EndDate", c => c.String());
            AlterColumn("dbo.Chain", "StartingDate", c => c.String());
            RenameTable(name: "dbo.CalendarEvents", newName: "CalenderEvents");
        }
    }
}
