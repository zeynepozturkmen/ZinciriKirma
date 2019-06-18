namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChainDetails", "ChainRingArchived", c => c.Boolean(nullable: false));
            DropColumn("dbo.ChainDetails", "ChainRingArchieved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChainDetails", "ChainRingArchieved", c => c.Boolean(nullable: false));
            DropColumn("dbo.ChainDetails", "ChainRingArchived");
        }
    }
}
