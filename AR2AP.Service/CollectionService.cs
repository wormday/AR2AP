using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;

namespace AR2AP.Service
{
    public class CollectionService
    {
        public void Add(CollectionEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetCollectionRepository();
                repository.Add(entity);
                trans.Commit();
            }
        }
        public IList<CollectionEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetCollectionRepository();
                return repository.FindBySpecification(o=>true).ToList();
            }
        }
    }
}
