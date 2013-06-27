﻿using System;
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
        public ActionResult CollectionAdd()
        {
            CollectionAddVModel vModel = new CollectionAddVModel();
            return View(vModel);
        }

        [HttpPost]
        public ActionResult CollectionAdd(CollectionAddVModel vModel)
        {
            return null;
        }

        [HttpGet]
        public ActionResult CollectionList()
        {
            return null;
        }
    }
}
