using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.DTO.Leaders;
using MongoDB.Driver;

namespace LeaderBase.Business.Abstract
{
    public interface ILeaderService
    {
        public List<LeaderDto> GetAll();

        public LeaderDto GetById(string id);

        public Task<LeaderDto> InsertOneAsync(LeaderIO entity);

        public Task<List<LeaderDto>> InsertManyAsync(List<LeaderIO> entity);

        public Task<ReplaceOneResult> UpsertOneAsync(Leader entity);

        public Task<DeleteResult> DeleteOneAsync(string id);
    }
}
