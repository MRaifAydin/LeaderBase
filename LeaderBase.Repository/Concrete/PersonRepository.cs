using LeaderBase.Core.Common;
using LeaderBase.Core.Entities;
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
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(IOptions<LeaderBaseDbSettings> _dbSettings) : base(_dbSettings)
        {
        }
    }
}