namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Matches", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "Time", c => c.Int(nullable: false));
        }
    }
}
