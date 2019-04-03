namespace NorthWindDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuppliersConfMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Suppliers", "CompanyName", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Suppliers", "CompanyName", c => c.String());
        }
    }
}
