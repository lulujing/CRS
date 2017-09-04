using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekerHunterServices.Models
{
     public class CandidateModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Skill> Skills { get; set; }
    }
    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
