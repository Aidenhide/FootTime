namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matchHuman : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "IsHouseHuman", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matches", "IsVisitorHuman", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "IsVisitorHuman");
            DropColumn("dbo.Matches", "IsHouseHuman");
        }
    }
}
