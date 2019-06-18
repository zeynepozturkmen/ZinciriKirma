namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_12 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CalendarEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        start = c.String(),
                        end = c.String(),
                        color = c.String(),
                        Description = c.String(),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
