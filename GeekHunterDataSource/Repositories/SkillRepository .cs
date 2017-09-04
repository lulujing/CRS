using GeekHunterDataSource.EF;
using GeekHunterDataSource.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace GeekHunterDataSource.Repositories
{
    public class SkillRepository : Repository<Skill, int>

    {
        public SkillRepository(DbContext context):base(context)
        {
        }

    }
}
