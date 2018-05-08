namespace TheSongDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondOrThirdMigrationImNotReallySure : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Friends");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        friendId = c.Int(nullable: false, identity: true),
                        friend1 = c.String(),
                        friend2 = c.String(),
                    })
                .PrimaryKey(t => t.friendId);
            
        }
    }
}
