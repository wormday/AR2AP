using System;
using System.Web.Mvc;
using AR2AP.BLL;
using AR2AP.WebApp.Models.Foundation;
using AR2AP.Service;

namespace AR2AP.WebApp.Controllers
{
    public class FoundationController : Controller
    {
        #region generic method
        private ActionResult List<TEntity, KService>()
            where TEntity : class
            where KService : ISimpleService<TEntity>, new()
        {
            var service = new KService();
            var vModel = new SimpleListVModel<TEntity>();
            vModel.Entities = service.GetEntities();
            return View(vModel);
        }
        private ActionResult Merge<TEntity, KService>(SimpleMergeVModel<TEntity> vModel)
            where TEntity : class
            where KService : ISimpleService<TEntity>, new()
        {
            try
            {
                var service = new KService();
                service.Merge(vModel.Entity);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("EmpEntity.Username", ex.Message);
            }
            return View(vModel);
        }
        private ActionResult Merge<TEntity, KService>(int? key)
            where TEntity : class
            where KService : ISimpleService<TEntity>, new()
        {
            SimpleMergeVModel<TEntity> vModel = new SimpleMergeVModel<TEntity>();
            if (key.HasValue)
            {
                var service = new KService();
                vModel.Entity = service.GetEntity(key.Value);
            }
            return View(vModel);
        }
        #endregion

        #region Employee
        public ActionResult EmpList()
        {
            return List<EmpEntity, EmpService>();
        }
        [HttpPost]
        public ActionResult EmpMerge(EmpMergeVModel vModel)
        {
            return Merge<EmpEntity, EmpService>(vModel);
        }
        [HttpGet]
        public ActionResult EmpMerge(int id)
        {
            return Merge<EmpEntity, EmpService>(id);
        }
        #endregion

        #region Term
        public ActionResult TermList()
        {
            return List<TermEntity,TermService>();
        }
        [HttpPost]
        public ActionResult TermMerge(TermMergeVModel vModel)
        {
            return Merge<TermEntity, TermService>(vModel);
        }
        [HttpGet]
        public ActionResult TermMerge(int? id)
        {
            return Merge<TermEntity, TermService>(id);
        }
        #endregion

        #region Agency
        public ActionResult AgencyList()
        {
            return List<AgencyEntity, AgencyService>();
        }
        [HttpPost]
        public ActionResult AgencyMerge(AgencyMergeVModel vModel)
        {
            return Merge<AgencyEntity, AgencyService>(vModel);
        }
        [HttpGet]
        public ActionResult AgencyMerge(int? id)
        {
            return Merge<AgencyEntity, AgencyService>(id);
        }
        #endregion

        #region Client
        public ActionResult ClientList()
        {
            return List<ClientEntity, ClientService>();
        }
        [HttpPost]
        public ActionResult ClientMerge(ClientMergeVModel vModel)
        {
            return Merge<ClientEntity, ClientService>(vModel);
        }
        [HttpGet]
        public ActionResult ClientMerge(int? id)
        {
            return Merge<ClientEntity, ClientService>(id);
        }
        #endregion
    }
}
