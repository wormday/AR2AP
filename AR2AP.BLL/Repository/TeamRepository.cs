using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.BLL.Repository
{
    public class TeamRepository : IRepository<TeamEntity, int>
    {
        protected readonly AR2APContainer _context;
        public TeamRepository(AR2APContainer context)
        {
            _context = context;
        }

        public void Add(TeamEntity entity)
        {
            _context.TeamEntities.Add(entity);
        }

        public TeamEntity GetByKey(int id)
        {
            return _context.TeamEntities.Where(o => o.TeamID == id).Single();
        }

        public IEnumerable<TeamEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<TeamEntity, bool>> spec)
        {
            return _context.TeamEntities.Where(spec);
        }
    }
}
