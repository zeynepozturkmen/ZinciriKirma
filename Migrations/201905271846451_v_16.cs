namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalenderEvents", "yapilmaSiklik", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalenderEvents", "yapilmaSiklik");
        }
    }
}
