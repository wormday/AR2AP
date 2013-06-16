using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.BLL.Repository
{
    public class TermRepository : IRepository<TermEntity, int>
    {
        protected readonly AR2APContainer _context;
        public TermRepository(AR2APContainer context)
        {
            _context = context;
        }

        public void Add(TermEntity entity)
        {
            _context.TermEntities.Add(entity);
        }

        public TermEntity GetByKey(int id)
        {
            return _context.TermEntities.Where(o => o.TermID == id).Single();
        }

        public IEnumerable<TermEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<TermEntity, bool>> spec)
        {
            return _context.TermEntities.Where(spec);
        }
    }
}
