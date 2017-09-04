using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekHunterDataSource.Repositories;
using GeekHunterDataSource.EF;

namespace GeekHunterDataSource.UnitOfWork
{
    public interface IGeekHunterUnitOfWork:IDisposable
    {
        IRepository<Candidate,int> Candidates { get; }
        IRepository<Skill, int> Skills { get; }
        IRepository<Candidate_Skills,int>CandidateSkills{get;}
        int Commit();
    }
}
