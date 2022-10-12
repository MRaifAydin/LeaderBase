using LeaderBase.Core.Entities;
using LeaderBase.DTO.Leaders;
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
        private readonly LeaderRepository _leaderRepository;

        public LeadersController(LeaderRepository leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }

        [HttpGet]
        public List<Leader> Get()
        {
            return _leaderRepository.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<LeaderDto> GetById(string id)
        //{
        //    return await _leaderRepository.GetLeaderDto(id);
        //}

        [HttpPost]
        public Task<Leader> InsertOne(Leader entity)
        {
            return _leaderRepository.InsertOneAsync(entity);
        }

        [HttpPost]
        [Route("Many")]
        public Task<List<Leader>> InsertMany(List<Leader> entities)
        {
            return _leaderRepository.InsertMany(entities);
        }

        [HttpPut]
        public Task<ReplaceOneResult> Update(Leader entity)
        {
            return _leaderRepository.UpsertAsync(entity);
        }

        [HttpDelete]
        public Task<DeleteResult> Delete(string id)
        {
            return _leaderRepository.DeleteAsync(id);
        }

    }
}
