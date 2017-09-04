
using GeekerHunterServices.Models;
using GeekHunterDataSource.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeekerHunterServices
{
    public interface ICRMService
    {
        List<Models.CandidateModel> GetCandidateList();
        List<Models.CandidateModel> GetCandidateListBySkill(string skillsString);
        bool CreateNewCandidate(int[] skills, CandidateModel candidate);
    }
}
