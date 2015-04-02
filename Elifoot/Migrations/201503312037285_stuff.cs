namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.GameEvents", "Location", c => c.Int(nullable: false));
            AlterColumn("dbo.GameEvents", "PlayerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameEvents", "PlayerName", c => c.Int(nullable: false));
            DropColumn("dbo.GameEvents", "Location");
            DropColumn("dbo.Matches", "Time");
        }
    }
}
