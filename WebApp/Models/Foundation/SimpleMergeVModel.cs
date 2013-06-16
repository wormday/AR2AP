using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;

namespace AR2AP.WebApp.Models.Foundation
{
    public class SimpleMergeVModel<T> where T : class
    {
        public T Entity { get; set; }
    }
}