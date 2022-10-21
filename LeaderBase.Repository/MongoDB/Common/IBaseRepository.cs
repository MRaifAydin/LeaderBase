using LeaderBase.Core.Common;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.MongoDB.Common
{
    public interface IBaseRepository<TSource> where TSource : BaseEntity
    {
        IMongoQueryable<TSource> GetAll(Expression<Func<TSource, bool>> predicate);

        TSource GetById(string id);


        Task<TSource> InsertOneAsync(TSource entity);
        Task<List<TSource>> InsertMany(List<TSource> entity);

        Task<ReplaceOneResult> UpsertAsync(TSource entity);

        Task<DeleteResult> DeleteAsync(string id);
    }
}
