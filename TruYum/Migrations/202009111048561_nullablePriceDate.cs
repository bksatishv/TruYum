namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablePriceDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuItem", "DateOfLaunch", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItem", "DateOfLaunch", c => c.DateTime(nullable: false));
        }
    }
}
