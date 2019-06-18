namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ChainDetails", "ChainRingDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.CalenderEvents", "yapilmaSiklik");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalenderEvents", "yapilmaSiklik", c => c.String());
            AlterColumn("dbo.ChainDetails", "ChainRingDate", c => c.String());
        }
    }
}
