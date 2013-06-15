//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AR2AP.BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AREntity
    {
        public AREntity()
        {
            this.ARRelatedEmpEntities = new HashSet<ARRelatedEmpEntity>();
            this.WriteOffEntities = new HashSet<WriteOffEntity>();
        }
    
        public int ARID { get; set; }
        public int ClientID { get; set; }
        public int AgencyID { get; set; }
        public string TermID { get; set; }
        public string ProjectNo { get; set; }
        public string ContractNo { get; set; }
        public string Campaingn { get; set; }
        public string CompaignStart { get; set; }
        public string CompaignEnd { get; set; }
        public string CompaignAmount { get; set; }
        public string DueDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public InvoiceTypeEnum InvoiceType { get; set; }
        public string InvoiceAmount { get; set; }
        public string RevenueConfirmationDate { get; set; }
        public string Remark { get; set; }
    
        public virtual ClientEntity ClientEntity { get; set; }
        public virtual AgencyEntity AgencyEntity { get; set; }
        public virtual TermEntity TermEntity { get; set; }
        public virtual ICollection<ARRelatedEmpEntity> ARRelatedEmpEntities { get; set; }
        public virtual ICollection<WriteOffEntity> WriteOffEntities { get; set; }
    }
}
