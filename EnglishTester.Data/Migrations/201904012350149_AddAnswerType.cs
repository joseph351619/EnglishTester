namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnswerType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Type");
            DropColumn("dbo.Answers", "Type");
        }
    }
}
