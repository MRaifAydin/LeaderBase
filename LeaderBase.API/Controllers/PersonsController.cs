using LeaderBase.Business.Abstract;
using LeaderBase.Core.Entities;
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
        public async Task<IActionResult> InsertOne(Person entity)
        {
            await _personService.InsertOneAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPost]
        [Route("Many")]
        public async Task<List<Person>> InsertMany(Person[] entities)
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
