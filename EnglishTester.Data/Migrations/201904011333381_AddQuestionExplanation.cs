namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionExplanation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Explanation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Explanation");
        }
    }
}
