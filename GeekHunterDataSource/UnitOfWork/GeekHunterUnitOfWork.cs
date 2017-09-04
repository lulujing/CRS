using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeekHunterDataSource.Repositories;
using GeekHunterDataSource.EF;
using System.Data.Entity;

namespace GeekHunterDataSource.UnitOfWork
{
    public class GeekHunterUnitOfWork:IGeekHunterUnitOfWork
    {
        private CandidateRepository _CandidateRepository;
        private SkillRepository _SkillRepository;
        private CandidateSkillRepository _SkillCandidateRepository;
        private DbContext _Context;

        public GeekHunterUnitOfWork(DbContext context)
        {
            this._Context = context;
            this._SkillRepository = new SkillRepository(context);
            this._CandidateRepository = new CandidateRepository(context);
            this._SkillCandidateRepository = new CandidateSkillRepository(context);
        }
        public IRepository<Candidate, int> Candidates
        {
            get
            {
                return this._CandidateRepository;
            }
        }


        public IRepository<Skill, int> Skills
        {
            get
            {
                return this._SkillRepository;
            }
        }
        public IRepository<Candidate_Skills, int> CandidateSkills
        {
            get
            {
                return this._SkillCandidateRepository;
            }
        }

        public int Commit()
        {
            return _Context.SaveChanges();
        }

        

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
