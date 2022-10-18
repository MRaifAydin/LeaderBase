using AutoMapper;
using LeaderBase.Core.Entities;
using LeaderBase.DTO.Leaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.Conversion.MapperProfiles
{
    public class LeaderProfile : Profile
    {
        public LeaderProfile()
        {
            CreateMap<Leader, LeaderDto>()
                .ForMember(x => x.Spouses, opt => opt.Ignore())
                .ForMember(x => x.Kids, opt => opt.Ignore())
                .ForMember(x => x.Father, opt => opt.Ignore())
                .ForMember(x => x.Mother, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
