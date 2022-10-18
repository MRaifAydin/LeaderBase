using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LeaderBase.Core.Entities;
using LeaderBase.DTO.Leaders;
using MongoDB.Driver;

namespace LeaderBase.Business.Abstract
{
    public interface ILeaderService
    {
        public List<LeaderDto> GetAll();

        public LeaderDto GetById(string id);

        public Task<Leader> InsertOneAsync(Leader entity);

        public Task<List<Leader>> InsertManyAsync(IEnumerable<Leader> entity);

        public Task<ReplaceOneResult> UpsertOneAsync(Leader entity);

        public Task<DeleteResult> DeleteOneAsync(string id);
    }
}
