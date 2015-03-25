namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Crap2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journeys", "Number", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Journeys", "Number");
        }
    }
}
