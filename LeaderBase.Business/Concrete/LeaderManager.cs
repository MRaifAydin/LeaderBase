using LeaderBase.Business.Abstract;
using LeaderBase.Conversion;
using LeaderBase.Core.Entities.Leader;
using LeaderBase.Core.Utilities.Constants;
using LeaderBase.Core.Utilities.Results;
using LeaderBase.DTO.Leaders;
using LeaderBase.DTO.Persons;
using LeaderBase.Repository.Abstract;
using MongoDB.Driver;
using SharpCompress.Common;
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

        private LeaderDto FillEntity(Leader leader)
        {
            LeaderDto response = leader.Map<LeaderDto>();
            response.Father = _personRepository.GetById(leader.FatherId).Map<PersonDto>();
            response.Mother = _personRepository.GetById(leader.MotherId).Map<PersonDto>();
            response.Kids = leader.KidsIds.Select(person => _personRepository.GetById(person).Map<PersonDto>()).ToList();
            response.Spouses = leader.SpousesIds.Select(person => _personRepository.GetById(person).Map<PersonDto>()).ToList();
            return response;
        }

        public IDataResult<List<LeaderDto>> GetAll()
        {
            List<Leader> entities = _leaderRepository.GetAll(_ => true).ToList();

            var response = entities.Select(entity => FillEntity(entity)).ToList();

            return new SuccessDataResult<List<LeaderDto>>(response);
        }

        public IDataResult<LeaderDto> GetById(string id)
        {
            var entity = _leaderRepository.GetById(id);

            LeaderDto leader = FillEntity(entity);

            return new SuccessDataResult<LeaderDto>(leader);
        }

        public IResult InsertOneAsync(LeaderIO entity)
        {
            Leader insertObject = entity.Map<Leader>();
            _leaderRepository.InsertOneAsync(insertObject);
            return new SuccessResult(Message.EntityAdded);
        }

        public IResult InsertManyAsync(List<LeaderIO> entity)
        {
            var insertObjects = entity.Select(x => x.Map<Leader>()).ToList();
            _leaderRepository.InsertMany(insertObjects);

            return new SuccessResult(Message.EntityAdded);
        }

        public IResult UpsertOneAsync(Leader entity)
        {
            _leaderRepository.UpsertAsync(entity);
            return new SuccessResult(Message.EntityUpserted);
        }

        public IResult DeleteOneAsync(string id)
        {
            _leaderRepository.DeleteAsync(id);
            return new SuccessResult(Message.EntityDeleted);
        }
    }
}
