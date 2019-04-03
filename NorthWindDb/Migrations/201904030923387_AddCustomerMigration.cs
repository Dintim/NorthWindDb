namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 5, fixedLength: true),
                        CompanyName = c.String(maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerDemographics",
                c => new
                    {
                        TypeId = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        CustomerDescription = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.TypeId);
            
            CreateTable(
                "dbo.CustomerCustomerDemo",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 5, fixedLength: true),
                        CustomerTypeId = c.String(nullable: false, maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.CustomerTypeId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerDemographics", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CustomerTypeId);
            
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerTypeId", "dbo.CustomerDemographics");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.CustomerCustomerDemo");
            DropTable("dbo.CustomerDemographics");
            DropTable("dbo.Customers");
        }
    }
}
