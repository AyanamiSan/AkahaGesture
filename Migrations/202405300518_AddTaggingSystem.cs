namespace Akaha_Gesture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaggingSystem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tag = c.String(),
                    })
                .PrimaryKey(t => t.id);
            CreateTable(
                "dbo.session_tag",
                c => new
                    {
                        session_id = c.DateTime(nullable: false),
                        tag_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.session_id, t.tag_id })
                .ForeignKey("dbo.tags", t => t.tag_id, cascadeDelete: true)
                .ForeignKey("dbo.sessions", t => t.session_id, cascadeDelete: true);
            // Add tag "gesture" to all existing database entries
            Sql("INSERT INTO dbo.tags (tag) VALUES ('gesture')");
            Sql("INSERT INTO dbo.session_tag (session_id, tag_id) SELECT start, (SELECT id FROM dbo.tags WHERE tag = \"gesture\") FROM dbo.sessions");
        }
        
        public override void Down()
        {
            DropTable("dbo.session_tag");
            DropTable("dbo.tags");
        }
    }
}
