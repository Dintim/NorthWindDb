namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTerritoryEmployeeMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTerritories",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        TerritoryId = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.TerritoryId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Territories", t => t.TerritoryId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.TerritoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTerritories", "TerritoryId", "dbo.Territories");
            DropForeignKey("dbo.EmployeeTerritories", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeTerritories", new[] { "TerritoryId" });
            DropIndex("dbo.EmployeeTerritories", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeTerritories");
        }
    }
}
