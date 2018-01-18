using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Examination.DbModels.DataContext;
using Examination.DbModels.Models;

namespace Examination.Services
{
    public class QuestionsService:IBasicService<Question>,IDisposable
    {
        private ExaminationContext _db = new ExaminationContext();
        public void AddQuestionAndAnswers(Question question,IList<Answer> answers,Guid goalId,Guid lessonId)
        {
            
                question.Id = Guid.NewGuid();
                question.GoalId = goalId;
                question.LessonId = lessonId;
                _db.Questions.Add(question);

                foreach (var answer in answers)
                {
                    answer.QuestionId = question.Id;
                }
                _db.Answers.AddRange(answers);
                _db.SaveChanges();
            
        }

        public void Add(Question question)
        {
            question.Id = Guid.NewGuid();
            _db.Questions.Add(question);

            foreach (var answer in question.Answers)
            {
                answer.QuestionId = question.Id;
                answer.Id = Guid.NewGuid();
            }
            _db.Answers.AddRange(question.Answers);
            _db.SaveChanges();
        }

        public Question GetById(Guid id)
        {
            return _db.Questions.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Question> Where(Expression<Func<Question, bool>> predicate)
        {
                return _db.Questions.Where(predicate);
        }

        public void Delete(Question entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
          _db.Dispose();   
        }
    }
}
