using LeaderBase.Business.Abstract;
using LeaderBase.Conversion;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.DTO.Leaders;
using LeaderBase.DTO.Persons;
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

            LeaderDto leader = entity.Map<LeaderDto>();

            leader.Father = _personRepository.GetById(entity.FatherId).Map<PersonDto>();
            leader.Mother = _personRepository.GetById(entity.MotherId).Map<PersonDto>();
            leader.Kids = entity.KidsIds.Select(person => _personRepository.GetById(person).Map<PersonDto>()).ToList();
            leader.Spouses = entity.SpousesIds.Select(person => _personRepository.GetById(person).Map<PersonDto>()).ToList();

            return leader;
        }

        public async Task<LeaderDto> InsertOneAsync(LeaderIO entity)
        {
            Leader insertObject = entity.Map<Leader>();
            await _leaderRepository.InsertOneAsync(insertObject);
            return GetById(insertObject.Id);
        }

        public async Task<List<LeaderDto>> InsertManyAsync(List<LeaderIO> entity)
        {
            var insertObjects = entity.Select(x => x.Map<Leader>()).ToList();
            await _leaderRepository.InsertMany(insertObjects);
            return insertObjects.Select(x => GetById(x.Id)).ToList();
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
