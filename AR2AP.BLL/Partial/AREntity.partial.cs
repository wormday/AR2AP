using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(AREntityMetadata))]
    public partial class AREntity
    {
        [Display(Name = "Invoice Type")]
        public InvoiceTypeEnum? InvoiceTypeEnum {
            get
            {
                if (InvoiceType != null)
                    return (InvoiceTypeEnum)InvoiceType;
                else
                    return null;
            }
            set {
                if (value.HasValue)
                    InvoiceType = (byte)value;
                else
                    InvoiceType = null;
            }
        }

        private class AREntityMetadata
        {
            [Required(ErrorMessage = "*")]
            [Display(Name = "ID")]
            public object ARID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Client")]
            public object ClientID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Agency")]
            public object AgencyID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Team")]
            public object TeamID { get; set; }
            [Display(Name = "Project No")]
            public object ProjectNo { get; set; }
            [Display(Name = "Contract No")]
            public object ContractNo { get; set; }
            [Display(Name = "Campaingn")]
            [Required(ErrorMessage = "*")]
            [StringLength(200, MinimumLength = 2, ErrorMessage = "{0} between {2} and {1} characters long.")]
            public object Campaingn { get; set; }
            [Display(Name = "Compaign Start")][UIHint("DateTime")]
            public object CompaignStart { get; set; }
            [Display(Name = "Compaign End")]
            [UIHint("DateTime")]
            public object CompaignEnd { get; set; }
            [Display(Name = "Compaign Amount")]
            public object CompaignAmount { get; set; }
            [Display(Name = "Due Date")]
            [UIHint("DateTime")]
            public object DueDate { get; set; }
            [Display(Name = "Invoice No")]
            public object InvoiceNo { get; set; }
            [Display(Name = "Invoice Date")]
            [UIHint("DateTime")]
            public object InvoiceDate { get; set; }
            [Display(Name = "Invoice Type")]
            public object InvoiceType { get; set; }
            [Display(Name = "Invoice Amount")]
            public object InvoiceAmount { get; set; }
            [Display(Name = "Revenue Confirmation Date")]
            [UIHint("DateTime")]
            public object RevenueConfirmationDate { get; set; }
            [Display(Name = "Remark")]
            public object Remark { get; set; }
        }
    }
}
