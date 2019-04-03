namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShipperMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionRescription = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        TerritoryDescription = c.String(maxLength: 50, fixedLength: true),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            AddColumn("dbo.Orders", "Shipper_Id", c => c.Int());
            CreateIndex("dbo.Orders", "EmployeeId");
            CreateIndex("dbo.Orders", "Shipper_Id");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Shipper_Id", "dbo.Shippers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Territories", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Orders", "Shipper_Id", "dbo.Shippers");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Territories", new[] { "RegionId" });
            DropIndex("dbo.Orders", new[] { "Shipper_Id" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropColumn("dbo.Orders", "Shipper_Id");
            DropTable("dbo.Territories");
            DropTable("dbo.Regions");
            DropTable("dbo.Shippers");
        }
    }
}
