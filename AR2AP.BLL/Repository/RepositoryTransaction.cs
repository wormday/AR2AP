﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AR2AP.BLL;

namespace AR2AP.BLL.Repository
{
    public class RepositoryTransaction:IDisposable
    {

        private readonly AR2APContainer _context;
        private Dictionary<Type, object> repositoryCache = new Dictionary<Type, object>();

        public RepositoryTransaction()
        {
            _context = new AR2APContainer();
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        #region 工厂
        public EmpRepository GetEmpRepository()
        {
            return new EmpRepository(_context);
        }
        public TermRepository GetTermRepository()
        {
            return new TermRepository(_context);
        }
        public AgencyRepository GetAgencyRepository()
        {
            return new AgencyRepository(_context);
        }
        public ClientRepository GetClientRepository()
        {
            return new ClientRepository(_context);
        }
        #endregion
    }
}