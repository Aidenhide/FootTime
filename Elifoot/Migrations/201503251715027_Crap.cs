namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Crap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        JourneyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        League_LeagueId = c.Int(),
                    })
                .PrimaryKey(t => t.JourneyId)
                .ForeignKey("dbo.Leagues", t => t.League_LeagueId)
                .Index(t => t.League_LeagueId);
            
            AddColumn("dbo.Leagues", "CurrentJourney", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "Journey_JourneyId", c => c.Int());
            CreateIndex("dbo.Matches", "Journey_JourneyId");
            AddForeignKey("dbo.Matches", "Journey_JourneyId", "dbo.Journeys", "JourneyId");
            DropColumn("dbo.Leagues", "Journey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leagues", "Journey", c => c.Int(nullable: false));
            DropForeignKey("dbo.Journeys", "League_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Matches", "Journey_JourneyId", "dbo.Journeys");
            DropIndex("dbo.Matches", new[] { "Journey_JourneyId" });
            DropIndex("dbo.Journeys", new[] { "League_LeagueId" });
            DropColumn("dbo.Matches", "Journey_JourneyId");
            DropColumn("dbo.Leagues", "CurrentJourney");
            DropTable("dbo.Journeys");
        }
    }
}
