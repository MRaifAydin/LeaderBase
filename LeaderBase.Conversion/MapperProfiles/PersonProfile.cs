using AutoMapper;
using LeaderBase.Core.Entities.Person;
using LeaderBase.DTO.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Conversion.MapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Person, PersonIO>().ReverseMap();
        }

    }
}
