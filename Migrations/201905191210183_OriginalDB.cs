namespace ZinciriKirma.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OriginalDB : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.aspnet_Users", "ApplicationId", "dbo.aspnet_Applications");
            DropForeignKey("dbo.aspnet_Roles", "ApplicationId", "dbo.aspnet_Applications");
            DropForeignKey("dbo.aspnet_Paths", "ApplicationId", "dbo.aspnet_Applications");
            DropForeignKey("dbo.aspnet_Membership", "ApplicationId", "dbo.aspnet_Applications");
            DropForeignKey("dbo.Chain", "UserId", "dbo.aspnet_Users");
            DropForeignKey("dbo.ChainDetails", "ChainID", "dbo.Chain");
            DropForeignKey("dbo.aspnet_UsersInRoles", "UserId", "dbo.aspnet_Users");
            DropForeignKey("dbo.aspnet_UsersInRoles", "RoleId", "dbo.aspnet_Roles");
            DropForeignKey("dbo.aspnet_Profile", "UserId", "dbo.aspnet_Users");
            DropForeignKey("dbo.aspnet_PersonalizationPerUser", "UserId", "dbo.aspnet_Users");
            DropForeignKey("dbo.aspnet_PersonalizationPerUser", "PathId", "dbo.aspnet_Paths");
            DropForeignKey("dbo.aspnet_PersonalizationAllUsers", "PathId", "dbo.aspnet_Paths");
            DropForeignKey("dbo.aspnet_Membership", "UserId", "dbo.aspnet_Users");
            DropIndex("dbo.aspnet_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.aspnet_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.ChainDetails", new[] { "ChainID" });
            DropIndex("dbo.Chain", new[] { "UserId" });
            DropIndex("dbo.aspnet_Roles", new[] { "ApplicationId" });
            DropIndex("dbo.aspnet_Profile", new[] { "UserId" });
            DropIndex("dbo.aspnet_PersonalizationAllUsers", new[] { "PathId" });
            DropIndex("dbo.aspnet_Paths", new[] { "ApplicationId" });
            DropIndex("dbo.aspnet_PersonalizationPerUser", new[] { "UserId" });
            DropIndex("dbo.aspnet_PersonalizationPerUser", new[] { "PathId" });
            DropIndex("dbo.aspnet_Users", new[] { "ApplicationId" });
            DropIndex("dbo.aspnet_Membership", new[] { "ApplicationId" });
            DropIndex("dbo.aspnet_Membership", new[] { "UserId" });
            DropTable("dbo.aspnet_UsersInRoles");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.aspnet_WebEvent_Events");
            DropTable("dbo.aspnet_SchemaVersions");
            DropTable("dbo.ChainDetails");
            DropTable("dbo.Chain");
            DropTable("dbo.aspnet_Roles");
            DropTable("dbo.aspnet_Profile");
            DropTable("dbo.aspnet_PersonalizationAllUsers");
            DropTable("dbo.aspnet_Paths");
            DropTable("dbo.aspnet_PersonalizationPerUser");
            DropTable("dbo.aspnet_Users");
            DropTable("dbo.aspnet_Membership");
            DropTable("dbo.aspnet_Applications");
        }
    }
}
