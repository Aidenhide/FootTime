namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameEventAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameEvents",
                c => new
                    {
                        GameEventId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Icon = c.String(),
                        Time = c.Int(nullable: false),
                        PlayerName = c.Int(nullable: false),
                        Match_MatchId = c.Int(),
                    })
                .PrimaryKey(t => t.GameEventId)
                .ForeignKey("dbo.Matches", t => t.Match_MatchId)
                .Index(t => t.Match_MatchId);
            
            AddColumn("dbo.Journeys", "time", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameEvents", "Match_MatchId", "dbo.Matches");
            DropIndex("dbo.GameEvents", new[] { "Match_MatchId" });
            DropColumn("dbo.Journeys", "time");
            DropTable("dbo.GameEvents");
        }
    }
}
