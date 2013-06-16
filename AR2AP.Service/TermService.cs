using System.Collections.Generic;
using System.Linq;
using AR2AP.BLL;
using AR2AP.BLL.Repository;


namespace AR2AP.Service
{
    public class TermService : ISimpleService<TermEntity>
    {
        public TermEntity GetEntity(int termID)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTermRepository();
                return repository.GetByKey(termID);
            }
        }
        public IList<TermEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTermRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }
        public void Merge(TermEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTermRepository();
                if (entity.TermID <= 0)
                {
                    repository.Add(entity);
                }
                else
                {
                    var orgEntity = repository.GetByKey(entity.TermID);
                    orgEntity.Depart = entity.Depart;
                    orgEntity.Market = entity.Market;
                }
                trans.Commit();
            }
        }
    }
}
