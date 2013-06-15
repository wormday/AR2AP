using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AR2AP.BLL.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetByKey(TKey id);
        IEnumerable<TEntity> FindBySpecification(Expression<Func<TEntity, bool>> spec);
    }
}
