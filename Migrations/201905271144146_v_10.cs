namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chain", "StartingDate", c => c.String());
            AlterColumn("dbo.Chain", "EndDate", c => c.String());
            AlterColumn("dbo.ChainDetails", "ChainRingDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ChainDetails", "ChainRingDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Chain", "EndDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Chain", "StartingDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
