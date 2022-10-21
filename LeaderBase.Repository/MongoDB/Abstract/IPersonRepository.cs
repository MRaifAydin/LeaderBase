using LeaderBase.Core.Common;
using LeaderBase.Core.Entities.Person;
using LeaderBase.Repository.MongoDB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.MongoDB.Abstract
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}
