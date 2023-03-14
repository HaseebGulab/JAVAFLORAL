namespace Floral_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        CID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Messagee = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Contact = c.String(),
                        Address = c.String(),
                        DateTime = c.String(),
                        U_Id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Registers", t => t.U_Id_Id)
                .Index(t => t.U_Id_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TotalAmount = c.String(),
                        Datetime = c.String(),
                        Qty = c.String(),
                        CustomerId_CustomerId = c.Int(),
                        OcassionId_OcassionId = c.Int(),
                        ProductId_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId_CustomerId)
                .ForeignKey("dbo.Ocassions", t => t.OcassionId_OcassionId)
                .ForeignKey("dbo.Products", t => t.ProductId_ProductId)
                .Index(t => t.CustomerId_CustomerId)
                .Index(t => t.OcassionId_OcassionId)
                .Index(t => t.ProductId_ProductId);
            
            CreateTable(
                "dbo.Ocassions",
                c => new
                    {
                        OcassionId = c.Int(nullable: false, identity: true),
                        OcassionName = c.String(),
                    })
                .PrimaryKey(t => t.OcassionId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Msg_Id = c.Int(nullable: false, identity: true),
                        Msg = c.String(),
                        OcassionId_OcassionId = c.Int(),
                    })
                .PrimaryKey(t => t.Msg_Id)
                .ForeignKey("dbo.Ocassions", t => t.OcassionId_OcassionId)
                .Index(t => t.OcassionId_OcassionId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.String(),
                        OcassionId_OcassionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Ocassions", t => t.OcassionId_OcassionId)
                .Index(t => t.OcassionId_OcassionId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "U_Id_Id", "dbo.Registers");
            DropForeignKey("dbo.Orders", "ProductId_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "OcassionId_OcassionId", "dbo.Ocassions");
            DropForeignKey("dbo.Orders", "OcassionId_OcassionId", "dbo.Ocassions");
            DropForeignKey("dbo.Messages", "OcassionId_OcassionId", "dbo.Ocassions");
            DropForeignKey("dbo.Orders", "CustomerId_CustomerId", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "OcassionId_OcassionId" });
            DropIndex("dbo.Messages", new[] { "OcassionId_OcassionId" });
            DropIndex("dbo.Orders", new[] { "ProductId_ProductId" });
            DropIndex("dbo.Orders", new[] { "OcassionId_OcassionId" });
            DropIndex("dbo.Orders", new[] { "CustomerId_CustomerId" });
            DropIndex("dbo.Customers", new[] { "U_Id_Id" });
            DropTable("dbo.Registers");
            DropTable("dbo.Products");
            DropTable("dbo.Messages");
            DropTable("dbo.Ocassions");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Contacts");
        }
    }
}
