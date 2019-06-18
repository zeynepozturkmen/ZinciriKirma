namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_18 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CalenderEvents");
            AlterColumn("dbo.CalenderEvents", "id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CalenderEvents", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CalenderEvents");
            AlterColumn("dbo.CalenderEvents", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CalenderEvents", "id");
        }
    }
}
