namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class talentadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        TalentName = c.String(maxLength: 75),
                        TalentLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID);
            
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 300));
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageFiles", "ImagePath", c => c.String(maxLength: 250));
            AlterColumn("dbo.Abouts", "AboutImage2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Abouts", "AboutImage1", c => c.String(maxLength: 100));
            DropTable("dbo.Talents");
        }
    }
}
