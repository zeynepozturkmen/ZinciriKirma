namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_20 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CalendarEvents", newName: "CalenderEvents");
            AddColumn("dbo.Chain", "color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chain", "color");
            RenameTable(name: "dbo.CalenderEvents", newName: "CalendarEvents");
        }
    }
}
