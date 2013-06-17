using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(EmpEntityMetadata))]
    public partial class EmpEntity
    {
        public class EmpEntityMetadata
        {
            [Required(ErrorMessage="*")]
            public string EmpName { get; set; }
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid Email Address")]
            public string EmpEmail { get; set; }
            [StringLength(16, MinimumLength = 4, ErrorMessage = "4 - 16 characters")]
            public string Username { get; set; }
            [StringLength(16, MinimumLength = 4, ErrorMessage = "4 - 16 characters")]
            public string Password { get; set; }
        }
    }
}
