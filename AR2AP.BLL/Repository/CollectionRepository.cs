using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AR2AP.BLL.Repository
{
    public class CollectionRepository : IRepository<CollectionEntity, int>
    {
        protected readonly AR2APContainer _context;
        public CollectionRepository(AR2APContainer context)
        {
            _context = context;
        }
        public void Add(CollectionEntity entity)
        {
            _context.CollectionEntities.Add(entity);
        }

        public CollectionEntity GetByKey(int id)
        {
            return _context.CollectionEntities.Where(o => o.ClientID == id).Single();
        }

        public IEnumerable<CollectionEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<CollectionEntity, bool>> spec)
        {
            return _context.CollectionEntities.Include("ClientEntity").Include("AgencyEntity").Where(spec);
        }
    }
}
