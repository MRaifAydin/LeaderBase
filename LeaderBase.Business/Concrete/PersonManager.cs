using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities;
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

            PersonDto person = new PersonDto
            {
                Id = entity.Id,
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                PlaceOfBirth = entity.PlaceOfBirth,
                Nationality = entity.Nationality
            };
            return person;
        }

        public Task<Person> InsertOneAsync(Person entity)
        {
            return _personRepository.InsertOneAsync(entity);
        }

        public Task<List<Person>> InsertManyAsync(Person[] entity)
        {
            return _personRepository.InsertMany(entity);
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
