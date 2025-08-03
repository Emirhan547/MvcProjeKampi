namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsDraft", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsDraft");
        }
    }
}
