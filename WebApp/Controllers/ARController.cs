using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AR2AP.BLL;
using AR2AP.WebApp.Models.AR;
using AR2AP.Service;

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
            vModel.AREntity = new AREntity();
            vModel.AREntity.InvoiceTypeEnum = InvoiceTypeEnum.服务业;
            return View(vModel);
        }
        [HttpPost]
        public ActionResult Add(AREntity entity)
        {
            AddVModel vModel = new AddVModel();
            ARService service = new ARService();
            service.Add(entity);
            return View(vModel);
        }
    }
}
