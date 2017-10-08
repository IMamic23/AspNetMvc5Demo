namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EmailAddress");
        }
    }
}
