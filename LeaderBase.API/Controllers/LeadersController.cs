using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.Core.Utilities.Results;
using LeaderBase.DTO.Leaders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver;
using IResult = LeaderBase.Core.Utilities.Results.IResult;

namespace LeaderBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadersController : ControllerBase
    {
        private readonly ILeaderService _leaderService;

        public LeadersController(ILeaderService leaderService)
        {
            _leaderService = leaderService;
        }

        [HttpGet]
        public IDataResult<List<LeaderDto>> Get()
        {
            return _leaderService.GetAll();
        }

        [HttpGet("{id}")]
        public IDataResult<LeaderDto> GetById(string id)
        {
            return _leaderService.GetById(id);
        }

        [HttpPost]
        public IResult InsertOne(LeaderIO entity)
        {
            return _leaderService.InsertOneAsync(entity);
        }

        [HttpPost]
        [Route("Many")]
        public IResult InsertMany(List<LeaderIO> entities)
        {
            return _leaderService.InsertManyAsync(entities);
        }

        [HttpPut]
        public IResult Update(Leader entity)
        {
            return _leaderService.UpsertOneAsync(entity);
        }

        [HttpDelete]
        public IResult Delete(string id)
        {
            return _leaderService.DeleteOneAsync(id);
        }

    }
}
