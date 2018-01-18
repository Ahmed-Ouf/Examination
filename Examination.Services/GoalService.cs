using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Examination.DbModels.DataContext;
using Examination.DbModels.Models;

namespace Examination.Services
{
    public class GoalService:IBasicService<Goal>
    {
        public IQueryable<Goal> GetGoalsOfLesson(Guid lessonId)
        {
            using (ExaminationContext db = new ExaminationContext())
            {
                return db.Goals.Where(g => g.LessonId == lessonId);
            }
        }

        public void Add(Goal entity)
        {
            using (ExaminationContext db = new ExaminationContext())
            {
                db.Goals.Add(entity);
                db.SaveChanges();
            }
        }

        public Goal GetById(Guid id)
        {
            using (ExaminationContext db = new ExaminationContext())
            {
                return db.Goals.FirstOrDefault(g=>g.Id==id);
            }
        }

        public IQueryable<Goal> Where(Expression<Func<Goal, bool>> predicate)
        {
            using (ExaminationContext db = new ExaminationContext())
            {
                return db.Goals.Where(predicate);
            }
        }

        public void Delete(Goal entity)
        {
            using (ExaminationContext db = new ExaminationContext())
            {
                var goal = GetById(entity.Id);
                db.Goals.Remove(goal);
                db.SaveChanges();
            }
        }
    }
}