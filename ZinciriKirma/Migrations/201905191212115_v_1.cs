namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Chain", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
