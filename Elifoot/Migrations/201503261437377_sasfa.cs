namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sasfa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "HouseName", c => c.String());
            AddColumn("dbo.Matches", "VisitorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "VisitorName");
            DropColumn("dbo.Matches", "HouseName");
        }
    }
}
