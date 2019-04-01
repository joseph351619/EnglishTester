namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAnswersTable : DbMigration
    {
        public override void Up()
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Answers");
        }
    }
}
