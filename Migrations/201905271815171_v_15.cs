namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalenderEvents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        start = c.String(),
                        end = c.String(),
                        color = c.String(),
                        allday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalenderEvents");
        }
    }
}
