using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AR2AP.BLL;
using AR2AP.WebApp.Models.Collection;
using AR2AP.Service;

namespace AR2AP.WebApp.Controllers
{
    public class CollectionController : Controller
    {
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
                CollectionService service = new CollectionService();
                service.Add(vModel.CollectionEntity);
            }
            return View(vModel);
        }

        [HttpGet]
        public ActionResult List()
        {
            ListVModel vModel = new ListVModel();
            CollectionService service = new CollectionService();
            vModel.CollectionEntities=service.GetEntities(null,false);
            return View(vModel);
        }
    }
}
