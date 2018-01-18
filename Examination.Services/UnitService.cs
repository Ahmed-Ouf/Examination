using System;
using System.Linq;
using System.Linq.Expressions;
using Examination.DbModels.DataContext;
using Examination.DbModels.Models;

namespace Examination.Services
{
    public class UnitService : IBasicService<Unit>, IDisposable
    {
        private ExaminationContext _db = new ExaminationContext();
        public void Add(Unit entity)
        {
            throw new NotImplementedException();
        }

        public Unit GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Unit> Where(Expression<Func<Unit, bool>> predicate)
        {
            return _db.Units.Where(predicate);
        }

        public void Delete(Unit entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _db.Dispose();

        }
    }
}