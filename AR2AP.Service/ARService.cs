using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;

namespace AR2AP.Service
{
    public class ARService
    {
        public void Add(AREntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetARRepository();
                repository.Add(entity);
                trans.Commit();
            }
        }
        public IList<AREntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetARRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }
        public AREntity GetByKey(int arId)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetARRepository();
                return repository.GetByKey(arId);
            }
        }
    }
}
