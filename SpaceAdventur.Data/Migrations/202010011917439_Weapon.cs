namespace SpaceAdventur.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Weapon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventurer", "Weapon", c => c.String());
            DropColumn("dbo.Adventurer", "Health");
            DropColumn("dbo.Adventurer", "Damage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adventurer", "Damage", c => c.Int(nullable: false));
            AddColumn("dbo.Adventurer", "Health", c => c.Int(nullable: false));
            DropColumn("dbo.Adventurer", "Weapon");
        }
    }
}
