namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsertTimeInQuestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "InsertTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "InsertTime");
        }
    }
}
