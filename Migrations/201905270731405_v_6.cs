namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CalendarEvents", "Description");
            DropColumn("dbo.CalendarEvents", "IsFullDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "IsFullDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.CalendarEvents", "Description", c => c.String());
        }
    }
}
