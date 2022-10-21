using LeaderBase.Core.Common;
using LeaderBase.Core.Entities.Person;
using LeaderBase.Repository.MongoDB.Abstract;
using LeaderBase.Repository.MongoDB.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.MongoDB.Concrete
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(IOptions<LeaderBaseDbSettings> _dbSettings) : base(_dbSettings)
        {
        }
    }
}