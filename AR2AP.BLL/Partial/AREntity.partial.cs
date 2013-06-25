using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(AREntityMetadata))]
    public partial class AREntity
    {


        private class AREntityMetadata
        {
            [Required(ErrorMessage = "*")]
            [Display(Name = "ID")]
            public int ARID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Client")]
            public short ClientID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Agency")]
            public short AgencyID { get; set; }
            [Required(ErrorMessage = "*")]
            [Display(Name = "Term")]
            public short TermID { get; set; }
            [Display(Name = "Project No")]
            public string ProjectNo { get; set; }
            [Display(Name = "Contract No")]
            public string ContractNo { get; set; }
            [Display(Name = "Campaingn")]
            public string Campaingn { get; set; }
            [Display(Name = "Compaign Start")]
            public string CompaignStart { get; set; }
            [Display(Name = "Compaign End")]
            public string CompaignEnd { get; set; }
            [Display(Name = "Compaign Amount")]
            public string CompaignAmount { get; set; }
            [Display(Name = "Due Date")]
            public string DueDate { get; set; }
            [Display(Name = "Invoice No")]
            public string InvoiceNo { get; set; }
            [Display(Name = "Invoice Date")]
            public string InvoiceDate { get; set; }
            [Display(Name = "Invoice Type")]
            public byte InvoiceType { get; set; }
            [Display(Name = "Invoice Amount")]
            public string InvoiceAmount { get; set; }
            [Display(Name = "Revenue Confirmation Date")]
            public string RevenueConfirmationDate { get; set; }
            [Display(Name = "Remark")]
            public string Remark { get; set; }
        }
    }
}
