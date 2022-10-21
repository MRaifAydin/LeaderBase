using LeaderBase.Business.Abstract;
using LeaderBase.Conversion;
using LeaderBase.Core.Entities.Person;
using LeaderBase.DTO.Persons;
using LeaderBase.Repository.MongoDB.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<PersonDto> GetAll()
        {
            var entities = _personRepository.GetAll(_ => true).ToList();
            return entities.Select(entity => GetById(entity.Id)).ToList();
        }

        public PersonDto GetById(string id)
        {
            var entity = _personRepository.GetById(id);

            PersonDto person = entity.Map<PersonDto>();
            return person;
        }

        public async Task<PersonDto> InsertOneAsync(PersonIO entity)
        {
            var insertObject = entity.Map<Person>();
            await _personRepository.InsertOneAsync(insertObject);
            return GetById(insertObject.Id);
        }

        public async Task<List<PersonDto>> InsertManyAsync(List<PersonIO> entity)
        {
            var insertObjects = entity.Select(x => x.Map<Person>()).ToList();
            insertObjects = await _personRepository.InsertMany(insertObjects);
            return insertObjects.Select(x => GetById(x.Id).Map<PersonDto>()).ToList();
        }

        public Task<ReplaceOneResult> UpsertOneAsync(Person entity)
        {
            return _personRepository.UpsertAsync(entity);
        }

        public Task<DeleteResult> DeleteOneAsync(string id)
        {
            return _personRepository.DeleteAsync(id);
        }
    }
}
