namespace SpaceAdventur.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Baddies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Planet", "NumOfBadGuys");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Planet", "NumOfBadGuys", c => c.Int(nullable: false));
        }
    }
}
