namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messageedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsTrash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsSpam", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsSpam");
            DropColumn("dbo.Messages", "IsTrash");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
