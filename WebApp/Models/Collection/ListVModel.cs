using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;

namespace AR2AP.WebApp.Models.Collection
{
    public class ListVModel
    {
        public IList<CollectionEntity> CollectionEntities { get; set; }
    }
}