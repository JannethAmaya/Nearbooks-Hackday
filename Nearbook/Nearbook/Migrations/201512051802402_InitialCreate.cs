namespace Nearbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Author = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        Copies = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Borrow",
                c => new
                    {
                        BorrowID = c.Int(nullable: false, identity: true),
                        BookID = c.String(maxLength: 128),
                        MemberID = c.Int(nullable: false),
                        Status = c.Int(),
                        InitialDate = c.DateTime(nullable: false),
                        FinalDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BorrowID)
                .ForeignKey("dbo.Book", t => t.BookID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.MemberID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrow", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Borrow", "BookID", "dbo.Book");
            DropIndex("dbo.Borrow", new[] { "MemberID" });
            DropIndex("dbo.Borrow", new[] { "BookID" });
            DropTable("dbo.Member");
            DropTable("dbo.Borrow");
            DropTable("dbo.Book");
        }
    }
}
