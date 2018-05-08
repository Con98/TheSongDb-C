namespace TheSongDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "User_userId", "dbo.Users");
            DropIndex("dbo.Friends", new[] { "User_userId" });
            DropColumn("dbo.Friends", "User_userId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        surname = c.String(),
                        userName = c.String(),
                        email = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            AddColumn("dbo.Friends", "User_userId", c => c.Int());
            CreateIndex("dbo.Friends", "User_userId");
            AddForeignKey("dbo.Friends", "User_userId", "dbo.Users", "userId");
        }
    }
}
