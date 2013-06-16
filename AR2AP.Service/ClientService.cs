using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;

namespace AR2AP.Service
{
    public class ClientService : ISimpleService<ClientEntity>
    {
        public ClientEntity GetEntity(int key)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetClientRepository();
                return repository.GetByKey(key);
            }
        }

        public IList<ClientEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetClientRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }

        public void Merge(ClientEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetClientRepository();
                if (entity.ClientID <= 0)
                {
                    repository.Add(entity);
                }
                else
                {
                    var orgEntity = repository.GetByKey(entity.ClientID);
                    orgEntity.ClientGroup = entity.ClientGroup;
                    orgEntity.ClientName = entity.ClientName;
                    orgEntity.ClientType = entity.ClientType;
                }
                trans.Commit();
            }
        }
    }
}
