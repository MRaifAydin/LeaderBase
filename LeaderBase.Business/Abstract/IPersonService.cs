using LeaderBase.Core.Entities;
using LeaderBase.DTO.Persons;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Business.Abstract
{
    public interface IPersonService
    {
        public List<PersonDto> GetAll();

        public PersonDto GetById(string id);

        public Task<Person> InsertOneAsync(Person entity);

        public Task<List<Person>> InsertManyAsync(Person[] entity);

        public Task<ReplaceOneResult> UpsertOneAsync(Person entity);

        public Task<DeleteResult> DeleteOneAsync(string id);
    }
}
