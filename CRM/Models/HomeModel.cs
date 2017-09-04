using GeekerHunterServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{

    public class skillMV
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class CandidateMV
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<skillMV> Skills { get; set; }  
    }
    public class CandidatesMV
    {
        public List<CandidateModel> CandidatesList { get; set; }

    }
}