namespace FinTool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonthlyReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Net = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Gain = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Loss = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegExStrings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SearchString = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        RegExString_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegExStrings", t => t.RegExString_Id)
                .Index(t => t.RegExString_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "RegExString_Id", "dbo.RegExStrings");
            DropForeignKey("dbo.RegExStrings", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "RegExString_Id" });
            DropIndex("dbo.RegExStrings", new[] { "Category_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.RegExStrings");
            DropTable("dbo.MonthlyReports");
            DropTable("dbo.Categories");
        }
    }
}
