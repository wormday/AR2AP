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
            AR2AP.Service.EmpService service = new Service.EmpService();
            EmpListVModel vModel=new EmpListVModel();
            vModel.EmpEntities=service.GetEntities();
            return View(vModel);
        }
        [HttpPost]
        public ActionResult EmpModify(EmpModifyVModel vModel)
        {
            try
            {
                AR2AP.Service.EmpService service = new Service.EmpService();
                service.Merge(vModel.EmpEntity);
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("EmpEntity.Username", ex.Message);
            }
            return View(vModel);
        }
        [HttpGet]
        public ActionResult EmpModify(int id)
        {
            EmpModifyVModel vModel = new EmpModifyVModel();
            if (id >= 0)
            {
                AR2AP.Service.EmpService service = new Service.EmpService();
                vModel.EmpEntity = service.GetEntity(id);
            }
            return View(vModel);
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
        #endregion
    }
}
