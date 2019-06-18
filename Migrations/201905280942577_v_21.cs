namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Chain", "color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chain", "color", c => c.String());
        }
    }
}
