using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;

namespace AR2AP.WebApp.Models.WriteOff
{
    public class WriteOffVModel
    {
        public WriteOffVModel()
        {
            WriteOffEntity = new WriteOffEntity();
        }
        public WriteOffEntity WriteOffEntity { get; set; }

        public IList<CollectionEntity> CollectionEntities { get; set; }
    }
}