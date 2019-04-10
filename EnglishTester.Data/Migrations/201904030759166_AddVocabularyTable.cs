namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVocabularyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Explanations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Explanation = c.String(),
                        VocabularyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vocabularies", t => t.VocabularyID, cascadeDelete: true)
                .Index(t => t.VocabularyID);
            
            CreateTable(
                "dbo.Vocabularies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        Explanation = c.String(),
                        QuestionNo = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        IsAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Questions", "VocabularyID", c => c.Int());
            CreateIndex("dbo.Questions", "VocabularyID");
            AddForeignKey("dbo.Questions", "VocabularyID", "dbo.Vocabularies", "ID");
            DropTable("dbo.Answers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Explanation = c.String(),
                        QuestionNo = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Questions", "VocabularyID", "dbo.Vocabularies");
            DropForeignKey("dbo.Explanations", "VocabularyID", "dbo.Vocabularies");
            DropIndex("dbo.Questions", new[] { "VocabularyID" });
            DropIndex("dbo.Explanations", new[] { "VocabularyID" });
            DropColumn("dbo.Questions", "VocabularyID");
            DropTable("dbo.Options");
            DropTable("dbo.Vocabularies");
            DropTable("dbo.Explanations");
        }
    }
}
