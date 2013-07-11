using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;
using System.Linq.Expressions;
using LinqKit;

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
        public IList<CollectionEntity> GetEntities(int? clientID,bool onlyUnWriteOff)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetCollectionRepository();
                return repository.FindBySpecification(CreateSpecExpression(clientID,onlyUnWriteOff)).ToList();
            }
        }
        private Expression<Func<CollectionEntity, bool>> CreateSpecExpression(int? clientID, bool onlyUnWriteOff)
        {
            Expression<Func<CollectionEntity, bool>> expression = PredicateBuilder.True<CollectionEntity>();
            if (clientID.HasValue)
                expression = expression.And(o => o.ClientID == clientID.Value);
            if (onlyUnWriteOff)
                expression = expression.And(o => o.CollectionAmount > o.WriteOffEntities.Sum(w => w.WriteOffAmount));
            return expression;
        }
    }
}
