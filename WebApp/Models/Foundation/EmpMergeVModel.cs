using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AR2AP.BLL;
using System.ComponentModel.DataAnnotations;
using AR2AP.Utility;

namespace AR2AP.WebApp.Models.Foundation
{
    public class EmpMergeVModel : SimpleMergeVModel<EmpEntity>
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var v in base.Validate(validationContext))
                yield return v;
            if (this.Entity.EmpName.IsNullOrWhiteSpace() || this.Entity.EmpName.Length < 2)
                yield return new ValidationResult("Invalid Employee Name!",new string[]{"Entity.EmpName"});
        }
    }
}