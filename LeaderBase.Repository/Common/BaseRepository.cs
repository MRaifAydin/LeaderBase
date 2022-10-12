using LeaderBase.Core.Common;
using Microsoft.Extensions.Options;
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

        public BaseRepository(IOptions<LeaderBaseDbSettings> _dbSettings)
        {
            _mongoClient = new MongoClient(_dbSettings.Value.ConnectionString);
            _mongoCollection = _mongoClient.GetDatabase(_dbSettings.Value.DatabaseName)
                .GetCollection<TSource>(typeof(TSource).Name);
        }

        TSource FillEntity(TSource entity)
        {
            if (entity.CreatedAt == null)
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.CreatedBy = "admin";
            }
            else
            {
                entity.LastModifiedAt = DateTime.UtcNow;
                entity.LastModifiedBy = "admin";
            }

            return entity;
        }

        IEnumerable<TSource> FillEntities(IEnumerable<TSource> entities)
        {
            return entities.Select(entity => FillEntity(entity));
        }


        /// <summary>
        /// Returns all documents in a collection.
        /// </summary>
        public List<TSource> GetAll() => _mongoCollection.Find(_ => true).ToList();

        /// <summary>
        /// Returns a specified document in a collection by id.
        /// </summary>
        public TSource GetById(string id) => _mongoCollection.Find(x => x.Id == id).FirstOrDefault();

        public async Task InsertOneAsync(TSource entity)
        {
            await _mongoCollection.InsertOneAsync(FillEntity(entity));
        }

        public async Task InsertMany(IEnumerable<TSource> entities)
        {
            await _mongoCollection.InsertManyAsync(FillEntities(entities));
        }

        public Task<ReplaceOneResult> UpsertAsync(TSource entity)
        {
            var filter = Builders<TSource>.Filter.Eq(x => x.Id, entity.Id);

            var testEntity = GetById(entity.Id);
            entity.CreatedAt = testEntity.CreatedAt;
            entity.CreatedBy = testEntity.CreatedBy;
            entity.LastModifiedAt = testEntity.LastModifiedAt;
            entity.LastModifiedBy = testEntity.LastModifiedBy;

            return _mongoCollection.ReplaceOneAsync(filter, FillEntity(entity),
            new ReplaceOptions
            {
                IsUpsert = true
            });
        }

        public Task DeleteAsync(string id)
        {
            return _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        //public Task<UpdateResult> DeleteAsync(Expression<Func<TSource, bool>> predicate)
        //{

        //    var updateDefinitions = new List<UpdateDefinition<TSource>>
        //    {
        //        Builders<TSource>.Update.Set(x => x.IsDeleted, true),
        //        Builders<TSource>.Update.Set(x => x.LastModifiedAt, DateTime.Now)
        //    };

        //    var update = Builders<TSource>.Update.Combine(updateDefinitions);
        //    var filter = predicate;
        //    return _mongoCollection.UpdateManyAsync(filter, update);
        //}
    }
}
