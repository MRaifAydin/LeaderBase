using LeaderBase.Core.Entities;
using LeaderBase.DTO.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBase.DTO.Leaders
{
    public class LeaderDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PlaceOfDeath { get; set; }
        public List<PersonDto> Spouses { get; set; }
        public List<PersonDto> Kids { get; set; }
        public PersonDto Father { get; set; }
        public PersonDto Mother { get; set; }
    }
}
