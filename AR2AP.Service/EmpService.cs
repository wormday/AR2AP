using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AR2AP.BLL;
using AR2AP.BLL.Repository;

namespace AR2AP.Service
{
    public class EmpService
    {
        public EmpEntity GetEmpEntity(string username, string password)
        {
            using (RepositoryTransaction trans = new RepositoryTransaction())
            {
                var repository = trans.GetEmpRepository();
                return repository.FindBySpecification(o => o.Username == username && o.Password == password).FirstOrDefault();
            }
        }
    }
}
