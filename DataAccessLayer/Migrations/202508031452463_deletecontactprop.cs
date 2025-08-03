namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletecontactprop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Message");
            DropColumn("dbo.Contacts", "IsSpam");
            DropColumn("dbo.Contacts", "IsTrash");
            DropColumn("dbo.Contacts", "IsDraft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsTrash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "IsSpam", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "Message", c => c.String());
        }
    }
}
