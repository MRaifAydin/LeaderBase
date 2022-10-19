using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities.Person;
using LeaderBase.DTO.Persons;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace LeaderBase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public List<PersonDto> Get()
        {
            return _personService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public PersonDto GetById(string id)
        {
            return _personService.GetById(id);
        }

        [HttpPost]
        public async Task<PersonDto> InsertOne(PersonIO entity)
        {
            return await _personService.InsertOneAsync(entity);
        }

        [HttpPost]
        [Route("Many")]
        public async Task<List<PersonDto>> InsertMany(List<PersonIO> entities)
        {
            return await _personService.InsertManyAsync(entities);
        }

        [HttpPut]
        public async Task<PersonDto> Upsert(Person entity)
        {
            await _personService.UpsertOneAsync(entity);
            return _personService.GetById(entity.Id);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteResult> Delete(string id)
        {
            return await _personService.DeleteOneAsync(id);
        }
    }
}
