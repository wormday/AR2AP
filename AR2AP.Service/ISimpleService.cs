using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR2AP.Service
{
    public interface ISimpleService<TEntity>
    {
        TEntity GetEntity(int key);
        IList<TEntity> GetEntities();
        void Merge(TEntity entity);
    }
}
