namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Managers", "isHuman", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "isHuman");
        }
    }
}
