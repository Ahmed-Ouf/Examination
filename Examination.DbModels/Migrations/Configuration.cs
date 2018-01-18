using System.Collections.Generic;
using Examination.DbModels.Models;

namespace Examination.DbModels.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Examination.DbModels.DataContext.ExaminationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examination.DbModels.DataContext.ExaminationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Units
            Unit unit1 = new Unit { Id = Guid.NewGuid(), Name = "Unit1" };
            Unit unit2 = new Unit { Id = Guid.NewGuid(), Name = "Unit2" };
            //lessons lesson <unit-lesson>
            Lesson lesson1_1 = new Lesson { Id = Guid.NewGuid(), Name = "Lesson1-1", UnitId = unit1.Id };
            Lesson lesson1_2 = new Lesson { Id = Guid.NewGuid(), Name = "Lesson1-2", UnitId = unit1.Id };

            Lesson lesson2_1 = new Lesson { Id = Guid.NewGuid(), Name = "Lesson2-1", UnitId = unit2.Id };
            //goals goal <unit-leson-goal>
            Goal goal1_1_1 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-1-1", LessonId = lesson1_1.Id };
            Goal goal1_1_2 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-1-2", LessonId = lesson1_1.Id };
            Goal goal1_1_3 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-1-3", LessonId = lesson1_1.Id };

            Goal goal1_2_1 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-2-1", LessonId = lesson1_2.Id };
            Goal goal1_2_2 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-2-2", LessonId = lesson1_2.Id };
            Goal goal1_2_3 = new Goal { Id = Guid.NewGuid(), GoalText = "goal1-2-3", LessonId = lesson1_2.Id };


            Goal goal2_1_1 = new Goal { Id = Guid.NewGuid(), GoalText = "goal2-1-1", LessonId = lesson2_1.Id };
            Goal goal2_1_2 = new Goal { Id = Guid.NewGuid(), GoalText = "goal2-1-2", LessonId = lesson2_1.Id };

            //question 
            Question question1 = new Question { Id = Guid.NewGuid(), QuestionBody = "How old are you ?", GoalId = goal1_1_1.Id, LessonId = lesson1_1.Id };
            Question question2 = new Question { Id = Guid.NewGuid(), QuestionBody = "How are you ?", GoalId = goal1_2_1.Id, LessonId = lesson2_1.Id };

            //Answers
            Answer answer1_A = new Answer { Id = Guid.NewGuid(), AnswerText = "-1", QuestionId = question1.Id, CorrectAnswer = false };
            Answer answer1_B = new Answer { Id = Guid.NewGuid(), AnswerText = "-3", QuestionId = question1.Id, CorrectAnswer = false };
            Answer answer1_C = new Answer { Id = Guid.NewGuid(), AnswerText = "21", QuestionId = question1.Id, CorrectAnswer = true };
            Answer answer1_D = new Answer { Id = Guid.NewGuid(), AnswerText = "-5", QuestionId = question1.Id, CorrectAnswer = false };


            Answer answer2_A = new Answer { Id = Guid.NewGuid(), AnswerText = "Fine", QuestionId = question2.Id, CorrectAnswer = true };
            Answer answer2_B = new Answer { Id = Guid.NewGuid(), AnswerText = "TV", QuestionId = question2.Id, CorrectAnswer = false };
            Answer answer2_C = new Answer { Id = Guid.NewGuid(), AnswerText = "Redio", QuestionId = question2.Id, CorrectAnswer = false };
            Answer answer2_D = new Answer { Id = Guid.NewGuid(), AnswerText = "Ice", QuestionId = question2.Id, CorrectAnswer = false };

            context.Units.AddOrUpdate(e=>e.Name,unit1, unit2);
            context.Lessons.AddOrUpdate(e => e.Name, lesson1_1, lesson1_2, lesson2_1);
            context.Goals.AddOrUpdate(e => e.GoalText, goal1_1_1, goal1_1_2, goal1_1_3, goal2_1_1, goal2_1_2, goal1_2_1, goal1_2_2, goal1_2_3);
            context.Questions.AddOrUpdate(e => e.QuestionBody, question1, question2);
            context.Answers.AddOrUpdate(e => e.AnswerText, answer1_A, answer1_B, answer1_C, answer1_D, answer2_A, answer2_B, answer2_C, answer2_D);
            context.SaveChanges();


        }
    }
}
