using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities;
using LeaderBase.DTO.Leaders;
using LeaderBase.Repository.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Concrete
{
    public class LeaderManager : ILeaderService
    {

        private readonly IPersonRepository _personRepository;
        private readonly ILeaderRepository _leaderRepository;

        public LeaderManager(IPersonRepository personRepository, ILeaderRepository leaderRepository)
        {
            _personRepository = personRepository;
            _leaderRepository = leaderRepository;
        }



        public List<LeaderDto> GetAll()
        {
            List<Leader> entities = _leaderRepository.GetAll(_ => true).ToList();

            return entities.Select(entity => GetById(entity.Id)).ToList();

        }

        public LeaderDto GetById(string id)
        {
            var entity = _leaderRepository.GetById(id);

            LeaderDto leader = new LeaderDto
            {
                Id = entity.Id,
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                DateOfDeath = entity.DateOfDeath,
                PlaceOfBirth = entity.PlaceOfBirth,
                PlaceOfDeath = entity.PlaceOfDeath,
                Father = _personRepository.GetById(entity.FatherId),
                Mother = _personRepository.GetById(entity.MotherId),
                Kids = entity.KidsIds.Select(person => _personRepository.GetById(person)).ToList(),
                Spouses = entity.SpousesIds.Select(person => _personRepository.GetById(person)).ToList()
            };

            return leader;

        }

        public async Task<Leader> InsertOneAsync(Leader entity)
        {
            return await _leaderRepository.InsertOneAsync(entity);
        }

        public async Task<List<Leader>> InsertManyAsync(IEnumerable<Leader> entity)
        {
            return await _leaderRepository.InsertMany(entity);
        }

        public Task<ReplaceOneResult> UpsertOneAsync(Leader entity)
        {
            return _leaderRepository.UpsertAsync(entity);
        }

        public Task<DeleteResult> DeleteOneAsync(string id)
        {
            return _leaderRepository.DeleteAsync(id);
        }
    }
}
