namespace LaunderySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabse : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "PasswordRecoveryKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "PasswordRecoveryKey", c => c.String());
        }
    }
}
