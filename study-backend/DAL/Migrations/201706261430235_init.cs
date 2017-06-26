namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Password, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Password" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropTable("dbo.Users");
        }
    }
}
