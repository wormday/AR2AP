using System.Collections.Generic;

namespace AR2AP.WebApp.Models.Foundation
{
    public class SimpleListVModel<T> where T:class
    {
        public IList<T> Entities { get; set; }
    }
}