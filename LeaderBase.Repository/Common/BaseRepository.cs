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
            if (entity.Id == null)
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
        public IMongoQueryable<TSource> GetAll(Expression<Func<TSource, bool>> predicate) => _mongoCollection.AsQueryable().Where(predicate);


        /// <summary>
        /// Returns a specified document in a collection by id.
        /// </summary>
        public TSource GetById(string id)
        {
            TSource entity = _mongoCollection.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            { return Activator.CreateInstance<TSource>(); }
            else
            { return entity; }
        }

        public async Task<TSource> InsertOneAsync(TSource entity)
        {
            await _mongoCollection.InsertOneAsync(FillEntity(entity));
            return entity;
        }

        public async Task<List<TSource>> InsertMany(List<TSource> entities)
        {
            await _mongoCollection.InsertManyAsync(FillEntities(entities));
            return entities;
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

        public async Task<DeleteResult> DeleteAsync(string id)
        {
            return await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

    }
}
