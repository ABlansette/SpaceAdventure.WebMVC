namespace SpaceAdventur.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fights : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventurer", "Xp", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adventurer", "Xp");
        }
    }
}
