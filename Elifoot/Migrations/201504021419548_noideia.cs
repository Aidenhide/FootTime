namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noideia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Team_TeamId1", c => c.Int());
            AddColumn("dbo.Players", "Team_TeamId2", c => c.Int());
            CreateIndex("dbo.Players", "Team_TeamId1");
            CreateIndex("dbo.Players", "Team_TeamId2");
            AddForeignKey("dbo.Players", "Team_TeamId1", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Players", "Team_TeamId2", "dbo.Teams", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "Team_TeamId2", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_TeamId1", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "Team_TeamId2" });
            DropIndex("dbo.Players", new[] { "Team_TeamId1" });
            DropColumn("dbo.Players", "Team_TeamId2");
            DropColumn("dbo.Players", "Team_TeamId1");
        }
    }
}
