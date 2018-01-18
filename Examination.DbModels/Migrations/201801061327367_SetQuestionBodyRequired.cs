namespace Examination.DbModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetQuestionBodyRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Question", "QuestionBody", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Question", "QuestionBody", c => c.String());
        }
    }
}
