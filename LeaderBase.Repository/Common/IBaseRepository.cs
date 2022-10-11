using LeaderBase.Core.Common;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Common
{
    public interface IBaseRepository<TSource> where TSource : BaseEntity
    {
        IMongoQueryable<TSource> GetAll();
        IMongoQueryable<TSource> GetAllWithDeleted();
        IMongoQueryable<TSource> Where(Expression<Func<TSource, bool>> predicate);
        IMongoQueryable<TSource> GetById(string id) => Where(x => x.Id == id);
        IMongoQueryable<TSource> GetByIdWithDeleted(string id);

        Task InsertOne(TSource entity);
        Task InsertMany(IEnumerable<TSource> entity);

        Task<ReplaceOneResult> UpsertAsync(TSource entity);

        Task<UpdateResult> DeleteAsync(string id);
        Task<UpdateResult> DeleteAsync(Expression<Func<TSource, bool>> predicate);
    }
}
