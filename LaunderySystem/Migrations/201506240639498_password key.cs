namespace LaunderySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "PasswordRecoveryKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "PasswordRecoveryKey");
        }
    }
}
