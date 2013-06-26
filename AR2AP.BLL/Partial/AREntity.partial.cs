﻿using System.ComponentModel.DataAnnotations;

namespace AR2AP.BLL
{
    [MetadataType(typeof(AREntityMetadata))]
    public partial class AREntity
    {
        [Display(Name = "Invoice Type")]
        public InvoiceTypeEnum InvoiceTypeEnum {
            get { return (InvoiceTypeEnum)InvoiceType; }
            set { InvoiceType = (byte)value; }
        }

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
            [Display(Name = "Team")]
            public short TeamID { get; set; }
            [Display(Name = "Project No")]
            public string ProjectNo { get; set; }
            [Display(Name = "Contract No")]
            public string ContractNo { get; set; }
            [Display(Name = "Campaingn")]
            public string Campaingn { get; set; }
            [Display(Name = "Compaign Start")][UIHint("DateTime")]
            public string CompaignStart { get; set; }
            [Display(Name = "Compaign End")]
            [UIHint("DateTime")]
            public string CompaignEnd { get; set; }
            [Display(Name = "Compaign Amount")]
            public string CompaignAmount { get; set; }
            [Display(Name = "Due Date")]
            [UIHint("DateTime")]
            public string DueDate { get; set; }
            [Display(Name = "Invoice No")]
            public string InvoiceNo { get; set; }
            [Display(Name = "Invoice Date")]
            [UIHint("DateTime")]
            public string InvoiceDate { get; set; }
            [Display(Name = "Invoice Type")]
            public byte InvoiceType { get; set; }
            [Display(Name = "Invoice Amount")]
            public string InvoiceAmount { get; set; }
            [Display(Name = "Revenue Confirmation Date")]
            [UIHint("DateTime")]
            public string RevenueConfirmationDate { get; set; }
            [Display(Name = "Remark")]
            public string Remark { get; set; }
        }
    }
}
