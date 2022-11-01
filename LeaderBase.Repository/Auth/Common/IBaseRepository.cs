using LeaderBase.Core.Auth.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Auth.Common
{
    public interface IBaseRepository<TSource> where TSource : BaseEntity
    {
        public IQueryable<TSource> GetAll();
        public IQueryable<TSource> Get(Expression<Func<TSource, bool>> predicate);
        public void InsertOneAsync(TSource entity);
        public void UpdateAsync(TSource entity);
        public void DeleteAsync(int id);
    }
}
