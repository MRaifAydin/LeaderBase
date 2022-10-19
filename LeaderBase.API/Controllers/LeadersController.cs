using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.DTO.Leaders;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
        public List<LeaderDto> Get()
        {
            return _leaderService.GetAll();
        }

        [HttpGet("{id}")]
        public LeaderDto GetById(string id)
        {
            return _leaderService.GetById(id);
        }

        [HttpPost]
        public async Task<LeaderDto> InsertOne(LeaderIO entity)
        {
            return await _leaderService.InsertOneAsync(entity);
        }

        [HttpPost]
        [Route("Many")]
        public async Task<List<LeaderDto>> InsertMany(List<LeaderIO> entities)
        {
            return await _leaderService.InsertManyAsync(entities);
        }

        [HttpPut]
        public async Task<LeaderDto> Update(Leader entity)
        {
            await _leaderService.UpsertOneAsync(entity);
            return _leaderService.GetById(entity.Id);
        }

        [HttpDelete]
        public async Task<DeleteResult> Delete(string id)
        {
            return await _leaderService.DeleteOneAsync(id);
        }

    }
}
