namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gameEventUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameEvents", "SecondPlayerName", c => c.String());
            AddColumn("dbo.GameEvents", "Team", c => c.String());
            AddColumn("dbo.GameEvents", "OtherTeam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameEvents", "OtherTeam");
            DropColumn("dbo.GameEvents", "Team");
            DropColumn("dbo.GameEvents", "SecondPlayerName");
        }
    }
}
