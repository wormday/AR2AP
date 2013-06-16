using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.BLL.Repository
{
    public class AgencyRepository : IRepository<AgencyEntity, int>
    {
        protected readonly AR2APContainer _context;
        public AgencyRepository(AR2APContainer context)
        {
            _context = context;
        }
        public void Add(AgencyEntity entity)
        {
            _context.AgencyEntities.Add(entity);
        }

        public AgencyEntity GetByKey(int id)
        {
            return _context.AgencyEntities.Where(o => o.AgencyID == id).Single();
        }

        public IEnumerable<AgencyEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<AgencyEntity, bool>> spec)
        {
            return _context.AgencyEntities.Where(spec);
        }
    }
}
