using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AR2AP.WebApp.Models.Account
{
    public class LoginVModel
    {
        [Required(ErrorMessage="*")]
        [StringLength(16,MinimumLength=4,ErrorMessage="*")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}