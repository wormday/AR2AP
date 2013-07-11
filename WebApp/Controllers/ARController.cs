using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AR2AP.BLL;
using AR2AP.WebApp.Models.AR;
using AR2AP.Service;
using AR2AP.WebApp.Models.WriteOff;
using LinqKit;

namespace AR2AP.WebApp.Controllers
{
    public class ARController : Controller
    {
        public ActionResult List()
        {
            ListVModel vModel = new ListVModel();
            ARService service=new ARService();
            vModel.AREntities = service.GetEntities();
            return View(vModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddVModel vModel = new AddVModel();
            return View(vModel);
        }

        [HttpPost]
        public ActionResult Add(AddVModel vModel)
        {
            if (ModelState.IsValid)
            {
                ARService service = new ARService();
                service.Add(vModel.AREntity);
            }
            return View(vModel);
        }

        [HttpGet]
        public ActionResult WriteOff(int arId)
        {
            ARService service = new ARService();
            var ar=service.GetByKey(arId);
            CollectionService cService=new CollectionService();
            WriteOffVModel vModel = new WriteOffVModel();
            vModel.WriteOffEntity.ARID = arId;
            vModel.CollectionEntities = cService.GetEntities(ar.ClientID, true);
            return View(vModel);
        }
        [HttpPost]
        public ActionResult WriteOff(WriteOffVModel vModel)
        {
            return View(vModel);
        }
    }
}
