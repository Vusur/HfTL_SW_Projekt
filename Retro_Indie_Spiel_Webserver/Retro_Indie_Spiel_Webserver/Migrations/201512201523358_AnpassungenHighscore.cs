namespace Retro_Indie_Spiel_Webserver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnpassungenHighscore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Highscore",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.Score })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Highscore", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Highscore", new[] { "UserId" });
            DropTable("dbo.Highscore");
        }
    }
}
