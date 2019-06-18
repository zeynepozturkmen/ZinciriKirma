namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CalenderEvents", newName: "CalendarEvents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CalendarEvents", newName: "CalenderEvents");
        }
    }
}
