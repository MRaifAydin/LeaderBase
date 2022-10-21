using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Core.PostgreSQL.Common;
using LeaderBase.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.PostgreSQL.Common
{
    public class BaseRepository<TSource> : IBaseRepository<TSource> where TSource : BaseEntity
    {
        private readonly AppDbContext context;
        private DbSet<TSource> entities;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

        TSource FillEntity(TSource entity)
        {
            if (entity.Id == null)
            {
                entity.CreatedAt = DateTime.Now;
                entity.CreatedBy = "Admin";
            }
            else
            {
                entity.LastModifiedAt = DateTime.Now;
                entity.LastModifiedBy = "Test";
            }

            return entity;
        }

        public TSource Get(int id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TSource> GetAll()
        {
            return entities.AsQueryable();
        }

        public async void InsertOneAsync(TSource entity)
        {
            entity = FillEntity(entity);
            await entities.AddAsync(entity);
            context.SaveChanges();
        }

        public async void UpdateAsync(TSource entity)
        {
            entity = FillEntity(entity);
            entities.Update(entity);
            context.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
            var entity = Get(id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
