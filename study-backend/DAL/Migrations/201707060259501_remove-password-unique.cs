namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepasswordunique : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Password" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "Password", unique: true);
        }
    }
}
