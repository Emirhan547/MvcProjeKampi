namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontactproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsSpam", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsTrash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsTrash");
            DropColumn("dbo.Contacts", "IsSpam");
        }
    }
}
