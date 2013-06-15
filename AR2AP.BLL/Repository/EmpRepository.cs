using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.BLL.Repository
{
    public class EmpRepository : IRepository<EmpEntity, int>
    {
        protected readonly AR2APContainer _context;
        public EmpRepository(AR2APContainer context)
        {
            _context = context;
        }

        public void Add(EmpEntity entity)
        {
            throw new NotImplementedException();
        }

        public EmpEntity GetByKey(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmpEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<EmpEntity, bool>> spec)
        {
            return _context.EmpEntities.Where(spec);
        }
    }
}
