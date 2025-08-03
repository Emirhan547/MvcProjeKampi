namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecategorydescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "CategoryDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 200));
        }
    }
}
