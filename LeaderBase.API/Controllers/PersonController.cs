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
    public class PersonController : ControllerBase
    {
        private PersonRepository _personRepository;
        public PersonController(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        [HttpGet]
        public List<Person> Get()
        {
            return _personRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Person GetById(string id)
        {
            return _personRepository.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Person entity)
        {
            await _personRepository.InsertOneAsync(entity);
            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPost("/many")]
        public async Task<List<Person>> InsertMany(IEnumerable<Person> entities)
        {
            await _personRepository.InsertMany(entities);
            return _personRepository.GetAll();
        }

        [HttpPut]
        public async Task<Person> Upsert(Person entity)
        {
            await _personRepository.UpsertAsync(entity);
            return _personRepository.GetById(entity.Id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _personRepository.DeleteAsync(id);
        }
    }
}
