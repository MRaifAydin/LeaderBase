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
        List<TSource> GetAll();

        TSource GetById(string id);


        Task InsertOneAsync(TSource entity);
        Task InsertMany(IEnumerable<TSource> entity);

        Task<ReplaceOneResult> UpsertAsync(TSource entity);

        Task DeleteAsync(string id);
        //Task<UpdateResult> DeleteAsync(Expression<Func<TSource, bool>> predicate);
    }
}
