using LeaderBase.Core.Common;
using LeaderBase.Core.Entities;
using LeaderBase.DTO.Leaders;
using LeaderBase.Repository.Abstract;
using LeaderBase.Repository.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Concrete
{
    public class LeaderRepository : BaseRepository<Leader>, ILeaderRepository
    {
        //private readonly IPersonRepository _personRepository;
        public LeaderRepository(IOptions<LeaderBaseDbSettings> _dbSettings) : base(_dbSettings)
        {

        }



        //public async Task<LeaderDto> GetLeaderDto(string id)
        //{
        //    var entity = GetById(id);

        //    LeaderDto leader = new LeaderDto
        //    {
        //        Id = entity.Id,
        //        Name = entity.Name,
        //        DateOfBirth = entity.DateOfBirth,
        //        DateOfDeath = entity.DateOfDeath,
        //        PlaceOfBirth = entity.PlaceOfBirth,
        //        PlaceOfDeath = entity.PlaceOfDeath,
        //        Father = _personRepository.GetById(entity.FatherId),
        //        Mother = _personRepository.GetById(entity.MotherId),
        //        Kids = entity.KidsIds.Select(person => _personRepository.GetById(person)).ToList(),
        //        Spouses = entity.SpousesIds.Select(person => _personRepository.GetById(person)).ToList()
        //    };

        //    return leader;
        //}
    }
}
