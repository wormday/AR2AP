using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;
using AR2AP.Utility;

namespace AR2AP.Service
{
    public class EmpService:ISimpleService<EmpEntity>
    {
        public EmpEntity GetEntity(string username, string password)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetEmpRepository();
                password=PasswordMD5(password);
                username = username.ToLower();
                return repository.FindBySpecification(o => o.Username == username && o.Password == password).FirstOrDefault();
            }
        }
        public EmpEntity GetEntity(int empID)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetEmpRepository();
                return repository.FindBySpecification(o => o.EmpID == empID).FirstOrDefault();
            }
        }
        public IList<EmpEntity> GetEntities()
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetEmpRepository();
                return repository.FindBySpecification(o => true).ToList();
            }
        }
        public void Merge(EmpEntity entity)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                TrimFields(entity);
                var repository = trans.GetEmpRepository();
                if (entity.EmpID <= 0)
                {
                    if (entity.Username.IsNullOrEmpty() || entity.Password.IsNullOrEmpty())
                    {
                        entity.Username = null;
                        entity.Password = null;
                    }
                    else
                    {
                        var sameUserameEntities=repository.FindBySpecification(o => o.Username == entity.Username.ToLower());
                        if (sameUserameEntities.Count() > 0)
                        {
                            throw new ApplicationException("Someone already has that username!Try another please!");
                        }
                    }
                    repository.Add(entity);
                }
                else
                {
                    var orgEntity=repository.GetByKey(entity.EmpID);
                    orgEntity.EmpEmail = entity.EmpEmail;
                    orgEntity.EmpName = entity.EmpName;
                    if (entity.Username.IsNullOrEmpty())
                    {
                        orgEntity.Username = null;
                        orgEntity.Password = null;
                    }
                    else
                    {
                        if (orgEntity.Username != entity.Username)
                        {
                            var sameUserameEntities = repository.FindBySpecification(o => o.Username == entity.Username.ToLower());
                            if (sameUserameEntities.Count() > 0 && sameUserameEntities.Single().EmpID != entity.EmpID)
                            {
                                throw new ApplicationException("Someone already has that username!Try another please!");
                            }
                            orgEntity.Username = entity.Username;
                        }
                        if (!entity.Password.IsNullOrEmpty())
                        {
                            orgEntity.Password = entity.Password;
                        }
                    }
                }
                trans.Commit();
            }
        }
        private void TrimFields(EmpEntity entity)
        {
            entity.EmpName = entity.EmpName.TrimString();
            entity.EmpEmail = entity.EmpEmail.TrimString().ToLower();
            if (!entity.Username.IsNullOrWhiteSpace())
            {
                entity.Username = entity.Username.TrimString().ToLower();
                if (!entity.Password.IsNullOrEmpty())
                {
                    entity.Password = PasswordMD5(entity.Password);
                }
            }
            else
            {
                entity.Username = null;
                entity.Password = null;
            }
        }
        private string PasswordMD5(string password)
        {
            string md5Key = "U93*%4jedhu8";
            return AR2AP.Utility.Common.MD5(password + md5Key).ToLower();
        }
    }
}
