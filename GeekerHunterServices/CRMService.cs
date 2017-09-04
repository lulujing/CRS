using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekerHunterServices.Models;
using GeekHunterDataSource.EF;
using GeekHunterDataSource.UnitOfWork;

namespace GeekerHunterServices
{
    public class CRMService : ICRMService
    {
        private GeekHunterUnitOfWork work;
         public CRMService()
        {
            this.work = new GeekHunterUnitOfWork(new GeekHunterEntities());
        }
        public bool CreateNewCandidate(int[] skills, CandidateModel candidate)
        {
            bool result = true;
            var NewCandidate = new Candidate()
                               {
                                  FirstName = candidate.FirstName,
                                  LastName=candidate.LastName,
                                };
            work.Candidates.Add(NewCandidate);
            if (skills != null)
            {
                for (int i = 0; i < skills.Length; i++)
                {
                    var skill = new Candidate_Skills()
                    {
                        CandidateId = NewCandidate.Id,
                        SkillId = skills[i]
                    };
                    work.CandidateSkills.Add(skill);
                }
            }
            work.Commit();
            return result;
        }

        public List<CandidateModel> GetCandidateList()
        {
                var result =new List<CandidateModel>();
                result = work.Candidates.GetAll()
                                        .Select(n => new CandidateModel
                                          {
                                            Id = (long)n.Id,
                                            FirstName = n.FirstName,
                                            LastName = n.LastName,
                                            Skills = n.Candidate_Skills == null ? null: 
                                            n.Candidate_Skills.Select(ck => new Models.Skill
                                            {
                                               Id=(int)ck.SkillId,
                                               Name=ck.Skill.Name
                                            }).ToList()})
                                           .ToList();             
                return result;
        }

        public List<CandidateModel> GetCandidateListBySkill(string skillsString)
        {
            var result = new List<CandidateModel>();
                result = work.Candidates.GetAll()
                                       .Select(n => new CandidateModel
                                       {
                                           Id = (long)n.Id,
                                           FirstName = n.FirstName,
                                           LastName = n.LastName,
                                           Skills = n.Candidate_Skills == null ? null :
                                           n.Candidate_Skills.Select(ck => new Models.Skill
                                           {
                                               Id = (int)ck.SkillId,
                                               Name = ck.Skill.Name
                                           }).ToList()
                                        })
                                          .ToList();
            string[] skills = skillsString.Split(',');
            if (skills[0] != "")
            {
                foreach(var s in skills)
                {
                    result = result.Where(f=>f.Skills.Exists(h=>h.Id==Convert.ToInt32(s))).ToList();
                }
     
            }
            return result;
        }
    }
}
