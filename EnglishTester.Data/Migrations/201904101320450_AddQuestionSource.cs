namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionSource : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionSources", "SourceTypeID", "dbo.SourceTypes");
            DropIndex("dbo.QuestionSources", new[] { "SourceTypeID" });
            AlterColumn("dbo.QuestionSources", "SourceTypeID", c => c.Int());
            CreateIndex("dbo.QuestionSources", "SourceTypeID");
            AddForeignKey("dbo.QuestionSources", "SourceTypeID", "dbo.SourceTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionSources", "SourceTypeID", "dbo.SourceTypes");
            DropIndex("dbo.QuestionSources", new[] { "SourceTypeID" });
            AlterColumn("dbo.QuestionSources", "SourceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionSources", "SourceTypeID");
            AddForeignKey("dbo.QuestionSources", "SourceTypeID", "dbo.SourceTypes", "ID", cascadeDelete: true);
        }
    }
}
