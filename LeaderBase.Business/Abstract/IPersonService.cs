using LeaderBase.Core.Entities.Person;
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

        public Task<PersonDto> InsertOneAsync(PersonIO entity);

        public Task<List<PersonDto>> InsertManyAsync(List<PersonIO> entity);

        public Task<ReplaceOneResult> UpsertOneAsync(Person entity);

        public Task<DeleteResult> DeleteOneAsync(string id);
    }
}
