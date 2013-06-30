using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;
namespace AR2AP.WebApp.Models.Collection
{
    public class AddVModel
    {
        public AddVModel()
        {
            CollectionEntity = new CollectionEntity();
            CollectionEntity.CollectionDate = DateTime.Today;
    }
        public CollectionEntity CollectionEntity { get; set; }
    }
}