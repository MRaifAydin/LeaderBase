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
    public class BaseRepository<TSource> : IBaseRepository<TSource> where TSource : BaseEntity
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<TSource> _mongoCollection;

        public BaseRepository(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _mongoCollection = mongoClient.GetDatabase("LeaderBase").GetCollection<TSource>(typeof(TSource).Name.ToLowerInvariant());
        }

        public IMongoQueryable<TSource> GetAll() => GetAllWithDeleted().Where(x => !x.IsDeleted);

        public IMongoQueryable<TSource> GetAllWithDeleted()
        {
            return _mongoCollection.AsQueryable();
        }

        public IMongoQueryable<TSource> GetByIdWithDeleted(string id)
        {
            return _mongoCollection.AsQueryable().Where(x => x.Id == id);
        }

        public IMongoQueryable<TSource> Where(Expression<Func<TSource, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public Task InsertOne(TSource entity)
        {
            return _mongoCollection.InsertOneAsync(entity);
        }

        public Task InsertMany(IEnumerable<TSource> entity)
        {
            return _mongoCollection.InsertManyAsync(entity);
        }

        public Task<ReplaceOneResult> UpsertAsync(TSource entity)
        {
            var filter = Builders<TSource>.Filter.Eq(x => x.Id, entity.Id);
            return _mongoCollection.ReplaceOneAsync(filter, entity,
            new ReplaceOptions
            {
                IsUpsert = true
            });
        }

        public Task<UpdateResult> DeleteAsync(string id)
        {
            var updateDefinitions = new List<UpdateDefinition<TSource>>
            {
                Builders<TSource>.Update.Set(x => x.IsDeleted, true),
                Builders<TSource>.Update.Set(x => x.LastModifiedAt, DateTime.Now)
            };

            var update = Builders<TSource>.Update.Combine(updateDefinitions);
            var filter = Builders<TSource>.Filter.Eq(x => x.Id, id);
            return _mongoCollection.UpdateOneAsync(filter, update);
        }

        public Task<UpdateResult> DeleteAsync(Expression<Func<TSource, bool>> predicate)
        {

            var updateDefinitions = new List<UpdateDefinition<TSource>>
            {
                Builders<TSource>.Update.Set(x => x.IsDeleted, true),
                Builders<TSource>.Update.Set(x => x.LastModifiedAt, DateTime.Now)
            };

            var update = Builders<TSource>.Update.Combine(updateDefinitions);
            var filter = predicate;
            return _mongoCollection.UpdateManyAsync(filter, update);
        }
    }
}
