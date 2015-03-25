namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyingOffers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        From_TeamId = c.Int(),
                        Player_PlayerId = c.Int(),
                        To_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Teams", t => t.From_TeamId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .ForeignKey("dbo.Teams", t => t.To_TeamId)
                .Index(t => t.From_TeamId)
                .Index(t => t.Player_PlayerId)
                .Index(t => t.To_TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManagerId = c.Int(nullable: false),
                        StadiumId = c.Int(nullable: false),
                        Moral = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Salaries = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Referee_RefereeId = c.Int(),
                        Referee_RefereeId1 = c.Int(),
                        League_LeagueId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Referees", t => t.Referee_RefereeId)
                .ForeignKey("dbo.Referees", t => t.Referee_RefereeId1)
                .ForeignKey("dbo.Leagues", t => t.League_LeagueId)
                .Index(t => t.Referee_RefereeId)
                .Index(t => t.Referee_RefereeId1)
                .Index(t => t.League_LeagueId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        DefenderRole = c.Int(nullable: false),
                        ForwardRole = c.Int(nullable: false),
                        MidFielderRile = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MarketValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Age = c.Int(nullable: false),
                        Nationality = c.Int(nullable: false),
                        Injured = c.Boolean(nullable: false),
                        Stamina = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Strength = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Technick = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Experience = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverallPower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Journey = c.Int(nullable: false),
                        FirstPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SecondPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirdPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LeagueId);
            
            CreateTable(
                "dbo.Referees",
                c => new
                    {
                        RefereeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        League_LeagueId = c.Int(),
                    })
                .PrimaryKey(t => t.RefereeId)
                .ForeignKey("dbo.Leagues", t => t.League_LeagueId)
                .Index(t => t.League_LeagueId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HouseScore = c.Int(nullable: false),
                        VisitorScore = c.Int(nullable: false),
                        Time = c.Int(nullable: false),
                        HouseBallTime = c.Int(nullable: false),
                        VisitorBallTime = c.Int(nullable: false),
                        HouseCorners = c.Int(nullable: false),
                        VisitorCorners = c.Int(nullable: false),
                        HouseFaults = c.Int(nullable: false),
                        VisitorFaults = c.Int(nullable: false),
                        HouseShots = c.Int(nullable: false),
                        VisitorShots = c.Int(nullable: false),
                        House_TeamId = c.Int(),
                        referee_RefereeId = c.Int(),
                        Visitor_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.House_TeamId)
                .ForeignKey("dbo.Referees", t => t.referee_RefereeId)
                .ForeignKey("dbo.Teams", t => t.Visitor_TeamId)
                .Index(t => t.House_TeamId)
                .Index(t => t.referee_RefereeId)
                .Index(t => t.Visitor_TeamId);
            
            CreateTable(
                "dbo.Stadia",
                c => new
                    {
                        StadiumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.Int(nullable: false),
                        TicketPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StadiumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Visitor_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "referee_RefereeId", "dbo.Referees");
            DropForeignKey("dbo.Matches", "House_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "League_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Referees", "League_LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Teams", "Referee_RefereeId1", "dbo.Referees");
            DropForeignKey("dbo.Teams", "Referee_RefereeId", "dbo.Referees");
            DropForeignKey("dbo.BuyingOffers", "To_TeamId", "dbo.Teams");
            DropForeignKey("dbo.BuyingOffers", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.BuyingOffers", "From_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Matches", new[] { "Visitor_TeamId" });
            DropIndex("dbo.Matches", new[] { "referee_RefereeId" });
            DropIndex("dbo.Matches", new[] { "House_TeamId" });
            DropIndex("dbo.Referees", new[] { "League_LeagueId" });
            DropIndex("dbo.Players", new[] { "Team_TeamId" });
            DropIndex("dbo.Teams", new[] { "League_LeagueId" });
            DropIndex("dbo.Teams", new[] { "Referee_RefereeId1" });
            DropIndex("dbo.Teams", new[] { "Referee_RefereeId" });
            DropIndex("dbo.BuyingOffers", new[] { "To_TeamId" });
            DropIndex("dbo.BuyingOffers", new[] { "Player_PlayerId" });
            DropIndex("dbo.BuyingOffers", new[] { "From_TeamId" });
            DropTable("dbo.Stadia");
            DropTable("dbo.Matches");
            DropTable("dbo.Managers");
            DropTable("dbo.Referees");
            DropTable("dbo.Leagues");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.BuyingOffers");
        }
    }
}
