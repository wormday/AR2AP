using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;

namespace AR2AP.Service
{
    public class AgencyService : ISimpleService<AgencyEntity>
    {

        public AgencyEntity GetEntity(int key)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetAgencyRepository();
                return repository.GetByKey(key);
            }
        }

        public IList<AgencyEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetAgencyRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }

        public void Merge(AgencyEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetAgencyRepository();
                if (entity.AgencyID <= 0)
                {
                    repository.Add(entity);
                }
                else
                {
                    var orgEntity = repository.GetByKey(entity.AgencyID);
                    orgEntity.AgencyName = entity.AgencyName;
                    orgEntity.CurrencyType = entity.CurrencyType;
                }
                trans.Commit();
            }
        }
    }
}
