using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;
using System.ComponentModel.DataAnnotations;

namespace AR2AP.WebApp.Models.Foundation
{
    public class SimpleMergeVModel<T> : IValidatableObject where T : class
    {
        public T Entity { get; set; }
        public string Url { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Entity == null)
                yield return new ValidationResult("Invalid Data!");
        }
    }
}