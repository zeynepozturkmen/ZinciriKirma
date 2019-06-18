namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEvents", "Description", c => c.String());
            AddColumn("dbo.CalendarEvents", "IsFullDay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalendarEvents", "IsFullDay");
            DropColumn("dbo.CalendarEvents", "Description");
        }
    }
}
