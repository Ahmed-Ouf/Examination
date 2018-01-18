using System;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Linq.Expressions;

namespace Examination.Services
{
    public interface IBasicService<T> where T:class
    {
        void Add(T entity);
        T GetById(Guid id);
        IQueryable<T> Where(Expression<Func<T,bool>> predicate );
        void Delete(T entity);
    }
}