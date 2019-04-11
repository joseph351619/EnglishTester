namespace EnglishTester.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVocabularyOriginID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vocabularies", "OriginID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vocabularies", "OriginID");
        }
    }
}
