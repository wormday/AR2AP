using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.BLL.Repository
{
    public class ClientRepository : IRepository<ClientEntity, int>
    {
        protected readonly AR2APContainer _context;
        public ClientRepository(AR2APContainer context)
        {
            _context = context;
        }
        public void Add(ClientEntity entity)
        {
            _context.ClientEntities.Add(entity);
        }

        public ClientEntity GetByKey(int id)
        {
            return _context.ClientEntities.Where(o => o.ClientID == id).Single();
        }

        public IEnumerable<ClientEntity> FindBySpecification(System.Linq.Expressions.Expression<Func<ClientEntity, bool>> spec)
        {
            return _context.ClientEntities.Where(spec);
        }
    }
}
