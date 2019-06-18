namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_5 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CalendarEvents");
            AlterColumn("dbo.CalendarEvents", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CalendarEvents", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CalendarEvents");
            AlterColumn("dbo.CalendarEvents", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CalendarEvents", "id");
        }
    }
}
