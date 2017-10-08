namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastUpdateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "LastUpdateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "LastUpdateDate");
            DropColumn("dbo.Customers", "LastUpdateDate");
        }
    }
}
