using System.Collections.Generic;
using System.Linq;
using AR2AP.BLL;
using AR2AP.BLL.Repository;


namespace AR2AP.Service
{
    public class TeamService : ISimpleService<TeamEntity>
    {
        public TeamEntity GetEntity(int TeamID)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTeamRepository();
                return repository.GetByKey(TeamID);
            }
        }
        public IList<TeamEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTeamRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }
        public void Merge(TeamEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetTeamRepository();
                if (entity.TeamID <= 0)
                {
                    repository.Add(entity);
                }
                else
                {
                    var orgEntity = repository.GetByKey(entity.TeamID);
                    orgEntity.Depart = entity.Depart;
                    orgEntity.Market = entity.Market;
                }
                trans.Commit();
            }
        }
    }
}
