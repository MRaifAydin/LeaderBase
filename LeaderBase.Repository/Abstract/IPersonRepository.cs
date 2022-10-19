﻿using LeaderBase.Core.Common;
using LeaderBase.Core.Entities.Person;
using LeaderBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Repository.Abstract
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
    }
}
