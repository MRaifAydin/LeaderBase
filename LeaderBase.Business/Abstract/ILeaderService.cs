using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.Core.Utilities.Results;
using LeaderBase.DTO.Leaders;
using MongoDB.Driver;

namespace LeaderBase.Business.Abstract
{
    public interface ILeaderService
    {
        public IDataResult<List<LeaderDto>> GetAll();

        public IDataResult<LeaderDto> GetById(string id);

        public IResult InsertOneAsync(LeaderIO entity);

        public IResult InsertManyAsync(List<LeaderIO> entity);

        public IResult UpsertOneAsync(Leader entity);

        public IResult DeleteOneAsync(string id);
    }
}
