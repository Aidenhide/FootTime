namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class class2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Players", "Team_TeamId1", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_TeamId2", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "Team_TeamId1" });
            DropIndex("dbo.Players", new[] { "Team_TeamId2" });
            AddColumn("dbo.Players", "Selected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "SubSelected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Players", "Team_TeamId1");
            DropColumn("dbo.Players", "Team_TeamId2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Team_TeamId2", c => c.Int());
            AddColumn("dbo.Players", "Team_TeamId1", c => c.Int());
            DropColumn("dbo.Players", "SubSelected");
            DropColumn("dbo.Players", "Selected");
            CreateIndex("dbo.Players", "Team_TeamId2");
            CreateIndex("dbo.Players", "Team_TeamId1");
            AddForeignKey("dbo.Players", "Team_TeamId2", "dbo.Teams", "TeamId");
            AddForeignKey("dbo.Players", "Team_TeamId1", "dbo.Teams", "TeamId");
        }
    }
}
