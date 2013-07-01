using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR2AP.BLL.Repository
{
    public class ARRepository : IRepository<AREntity, int>
    {
        protected readonly AR2APContainer _context;
        public ARRepository(AR2APContainer context)
        {
            _context = context;
        }
        public void Add(AREntity entity)
        {
            _context.AREntities.Add(entity);
        }

        public AREntity GetByKey(int id)
        {
            return _context.AREntities.Where(o => o.ClientID == id).Single();
        }

        public IEnumerable<AREntity> FindBySpecification(System.Linq.Expressions.Expression<Func<AREntity, bool>> spec)
        {
            return _context.AREntities
                .Include("TeamEntity")
                .Include("AgencyEntity")
                .Include("ClientEntity")
                .Where(spec);
        }
    }
}
