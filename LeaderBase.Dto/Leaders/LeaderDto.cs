using LeaderBase.Core.Entities;
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
        public List<Person> Spouses { get; set; }
        public List<Person> Kids { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
    }
}
