﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;

namespace AR2AP.WebApp.Models.AR
{
    public class ListVModel
    {
        public IList<AREntity> AREntities { get; set; }
    }
}