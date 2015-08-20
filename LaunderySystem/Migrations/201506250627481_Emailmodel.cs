namespace LaunderySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emailmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailSettingModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SMTPServer = c.String(),
                        SMTPServerEmailID = c.String(),
                        SMTPDefaultSender = c.String(),
                        SMTPUserName = c.String(),
                        SMTPmailToCompany = c.String(),
                        SMTPpassword = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailSettingModels");
        }
    }
}
