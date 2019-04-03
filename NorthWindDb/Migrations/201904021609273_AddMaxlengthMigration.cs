namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxlengthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Country", c => c.String(maxLength: 15));
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employees", "Title", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employees", "TitleOfCourtesy", c => c.String(maxLength: 25));
            AlterColumn("dbo.Employees", "Address", c => c.String(maxLength: 60));
            AlterColumn("dbo.Employees", "City", c => c.String(maxLength: 15));
            AlterColumn("dbo.Employees", "Region", c => c.String(maxLength: 15));
            AlterColumn("dbo.Employees", "PostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employees", "HomePhone", c => c.String(maxLength: 24));
            AlterColumn("dbo.Employees", "Extension", c => c.String(maxLength: 4));
            AlterColumn("dbo.Employees", "PhotoPath", c => c.String(maxLength: 255));
            AlterColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 5, fixedLength: true));
            AlterColumn("dbo.Orders", "ShipName", c => c.String(maxLength: 40));
            AlterColumn("dbo.Orders", "ShipAddress", c => c.String(maxLength: 60));
            AlterColumn("dbo.Orders", "ShipCity", c => c.String(maxLength: 15));
            AlterColumn("dbo.Orders", "ShipRegion", c => c.String(maxLength: 15));
            AlterColumn("dbo.Orders", "ShipPostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "ShipCountry", c => c.String(maxLength: 15));
            AlterColumn("dbo.Products", "ProductName", c => c.String(maxLength: 40));
            AlterColumn("dbo.Products", "QuantityPerUnit", c => c.String(maxLength: 20));
            AlterColumn("dbo.Suppliers", "ContactName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Suppliers", "ContactTitle", c => c.String(maxLength: 30));
            AlterColumn("dbo.Suppliers", "Address", c => c.String(maxLength: 60));
            AlterColumn("dbo.Suppliers", "City", c => c.String(maxLength: 15));
            AlterColumn("dbo.Suppliers", "Region", c => c.String(maxLength: 15));
            AlterColumn("dbo.Suppliers", "PostalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Suppliers", "Country", c => c.String(maxLength: 15));
            AlterColumn("dbo.Suppliers", "Phone", c => c.String(maxLength: 24));
            AlterColumn("dbo.Suppliers", "Fax", c => c.String(maxLength: 24));
            AlterColumn("dbo.Suppliers", "HomePage", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "HomePage", c => c.String());
            AlterColumn("dbo.Suppliers", "Fax", c => c.String());
            AlterColumn("dbo.Suppliers", "Phone", c => c.String());
            AlterColumn("dbo.Suppliers", "Country", c => c.String());
            AlterColumn("dbo.Suppliers", "PostalCode", c => c.String());
            AlterColumn("dbo.Suppliers", "Region", c => c.String());
            AlterColumn("dbo.Suppliers", "City", c => c.String());
            AlterColumn("dbo.Suppliers", "Address", c => c.String());
            AlterColumn("dbo.Suppliers", "ContactTitle", c => c.String());
            AlterColumn("dbo.Suppliers", "ContactName", c => c.String());
            AlterColumn("dbo.Products", "QuantityPerUnit", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Orders", "ShipCountry", c => c.String());
            AlterColumn("dbo.Orders", "ShipPostalCode", c => c.String());
            AlterColumn("dbo.Orders", "ShipRegion", c => c.String());
            AlterColumn("dbo.Orders", "ShipCity", c => c.String());
            AlterColumn("dbo.Orders", "ShipAddress", c => c.String());
            AlterColumn("dbo.Orders", "ShipName", c => c.String());
            AlterColumn("dbo.Orders", "CustomerId", c => c.String());
            AlterColumn("dbo.Employees", "PhotoPath", c => c.String());
            AlterColumn("dbo.Employees", "Extension", c => c.String());
            AlterColumn("dbo.Employees", "HomePhone", c => c.String());
            AlterColumn("dbo.Employees", "PostalCode", c => c.String());
            AlterColumn("dbo.Employees", "Region", c => c.String());
            AlterColumn("dbo.Employees", "City", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "TitleOfCourtesy", c => c.String());
            AlterColumn("dbo.Employees", "Title", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            DropColumn("dbo.Employees", "Country");
        }
    }
}
