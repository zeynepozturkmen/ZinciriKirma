namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CalendarEvents", "allDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "allDay", c => c.Boolean(nullable: false));
        }
    }
}
