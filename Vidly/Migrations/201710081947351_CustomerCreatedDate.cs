namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateCreated");
        }
    }
}
