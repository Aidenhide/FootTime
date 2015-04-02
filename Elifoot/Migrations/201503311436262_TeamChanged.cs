namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "humanControl", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "humanControl");
        }
    }
}
