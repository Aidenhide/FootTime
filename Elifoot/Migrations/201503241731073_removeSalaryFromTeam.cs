namespace Elifoot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSalaryFromTeam : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Teams", "Salaries");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Salaries", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
