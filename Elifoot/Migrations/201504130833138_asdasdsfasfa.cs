namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasdsfasfa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "BackgroundColor", c => c.String());
            AddColumn("dbo.Teams", "ForegroundColor", c => c.String());
            AddColumn("dbo.Teams", "CrestUrl", c => c.String());
            AddColumn("dbo.Journeys", "IsOver", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matches", "HouseForegroundColor", c => c.String());
            AddColumn("dbo.Matches", "HouseBackgroundColor", c => c.String());
            AddColumn("dbo.Matches", "VisitorForegroundColor", c => c.String());
            AddColumn("dbo.Matches", "VisitorBackgroundColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "VisitorBackgroundColor");
            DropColumn("dbo.Matches", "VisitorForegroundColor");
            DropColumn("dbo.Matches", "HouseBackgroundColor");
            DropColumn("dbo.Matches", "HouseForegroundColor");
            DropColumn("dbo.Journeys", "IsOver");
            DropColumn("dbo.Teams", "CrestUrl");
            DropColumn("dbo.Teams", "ForegroundColor");
            DropColumn("dbo.Teams", "BackgroundColor");
        }
    }
}
