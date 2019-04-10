namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVocabularyAndQuestionRelatedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionSources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        SourceTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SourceTypes", t => t.SourceTypeID, cascadeDelete: true)
                .Index(t => t.SourceTypeID);
            
            CreateTable(
                "dbo.SourceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Questions", "SourceID", c => c.Int());
            AddColumn("dbo.Options", "Content", c => c.String());
            CreateIndex("dbo.Questions", "SourceID");
            AddForeignKey("dbo.Questions", "SourceID", "dbo.QuestionSources", "ID");
            DropColumn("dbo.Options", "Option");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Options", "Option", c => c.String());
            DropForeignKey("dbo.QuestionSources", "SourceTypeID", "dbo.SourceTypes");
            DropForeignKey("dbo.Questions", "SourceID", "dbo.QuestionSources");
            DropIndex("dbo.QuestionSources", new[] { "SourceTypeID" });
            DropIndex("dbo.Questions", new[] { "SourceID" });
            DropColumn("dbo.Options", "Content");
            DropColumn("dbo.Questions", "SourceID");
            DropTable("dbo.SourceTypes");
            DropTable("dbo.QuestionSources");
        }
    }
}
