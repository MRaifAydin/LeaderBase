using LeaderBase.Core.Entities;
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
        private PersonRepository _personRepository;
        public PersonsController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        public List<Person> Get()
        {
            return _personRepository.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Person GetById(string id)
        {
            return _personRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOne(Person entity)
        {
            await _personRepository.InsertOneAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPost]
        [Route("Many")]
        public async Task<List<Person>> InsertMany(IEnumerable<Person> entities)
        {
            return await _personRepository.InsertMany(entities);
        }

        [HttpPut]
        public async Task<Person> Upsert(Person entity)
        {
            await _personRepository.UpsertAsync(entity);
            return _personRepository.GetById(entity.Id);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteResult> Delete(string id)
        {
            return await _personRepository.DeleteAsync(id);
        }
    }
}
