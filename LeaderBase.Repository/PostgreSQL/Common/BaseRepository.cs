using LeaderBase.Core.Entities.PostgreSQL.Authentication;
using LeaderBase.Core.PostgreSQL.Common;
using LeaderBase.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //public DbSet<Type> Table()
        //{
        //    return Table<Type>();
        //}

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

        public IQueryable<TSource> Get(Expression<Func<TSource, bool>> predicate)
        {
            return context.Set<TSource>().Where(predicate);
        }

        public IQueryable<TSource> GetAll()
        {
            return context.Set<TSource>().AsQueryable();
        }

        public async void InsertOneAsync(TSource entity)
        {
            entity = FillEntity(entity);
            await context.Set<TSource>().AddAsync(entity);
            context.SaveChanges();
        }

        public async void UpdateAsync(TSource entity)
        {
            entity = FillEntity(entity);
            context.Set<TSource>().Update(entity);
            context.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
            var entity = Get(x => x.Id == id);
            context.Set<TSource>().Remove(entity.FirstOrDefault());
            context.SaveChanges();
        }
    }
}
