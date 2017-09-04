using GeekHunterDataSource.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeekHunterDataSource.Repositories
{
    class CandidateSkillRepository : Repository<Candidate_Skills, int>

    {
        public CandidateSkillRepository(DbContext context) : base(context)
        {
        }
    }
}
