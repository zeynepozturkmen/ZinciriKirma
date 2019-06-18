namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chain", "EndDate");
        }
    }
}
