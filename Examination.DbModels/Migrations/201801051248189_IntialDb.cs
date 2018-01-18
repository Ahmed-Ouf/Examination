namespace Examination.DbModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AnswerText = c.String(),
                        QuestionId = c.Guid(nullable: false),
                        CorrectAnswer = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        QuestionBody = c.String(),
                        LessonId = c.Guid(nullable: false),
                        GoalId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lesson", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Goal", t => t.GoalId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.GoalId);
            
            CreateTable(
                "dbo.Goal",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GoalText = c.String(),
                        LessonId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lesson", t => t.LessonId)
                .Index(t => t.LessonId);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        UnitId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Unit", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "GoalId", "dbo.Goal");
            DropForeignKey("dbo.Goal", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Lesson", "UnitId", "dbo.Unit");
            DropForeignKey("dbo.Question", "LessonId", "dbo.Lesson");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.Lesson", new[] { "UnitId" });
            DropIndex("dbo.Goal", new[] { "LessonId" });
            DropIndex("dbo.Question", new[] { "GoalId" });
            DropIndex("dbo.Question", new[] { "LessonId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropTable("dbo.Unit");
            DropTable("dbo.Lesson");
            DropTable("dbo.Goal");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
