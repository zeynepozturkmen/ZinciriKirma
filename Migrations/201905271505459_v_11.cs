namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chain", "color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chain", "color");
        }
    }
}
