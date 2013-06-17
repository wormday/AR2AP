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
    
    /// <summary>应收账款(AR)实体</summary>
    public partial class AREntity
    {
        public AREntity()
        {
            this.ARRelatedEmpEntities = new HashSet<ARRelatedEmpEntity>();
            this.WriteOffEntities = new HashSet<WriteOffEntity>();
        }
        /// <summary>AR编号</summary>
        public int ARID { get; set; }
        /// <summary>客户编号</summary>
        public short ClientID { get; set; }
        public short AgencyID { get; set; }
        public short TermID { get; set; }
        /// <summary>项目编号</summary>
        public string ProjectNo { get; set; }
        /// <summary>合同编号</summary>
        public string ContractNo { get; set; }
        /// <summary>项目</summary>
        public string Campaingn { get; set; }
        /// <summary>项目开始日期</summary>
        public string CompaignStart { get; set; }
        /// <summary>项目结束日期</summary>
        public string CompaignEnd { get; set; }
        /// <summary>项目金额</summary>
        public string CompaignAmount { get; set; }
        /// <summary>收款到期日</summary>
        public string DueDate { get; set; }
        /// <summary>发票号码</summary>
        public string InvoiceNo { get; set; }
        /// <summary>开票时间</summary>
        public string InvoiceDate { get; set; }
        public byte InvoiceType { get; set; }
        /// <summary>发票金额</summary>
        public string InvoiceAmount { get; set; }
        /// <summary>应收确认时间</summary>
        public string RevenueConfirmationDate { get; set; }
        public string Remark { get; set; }
    
        public virtual ClientEntity ClientEntity { get; set; }
        public virtual AgencyEntity AgencyEntity { get; set; }
        public virtual TeamEntity TeamEntity { get; set; }
        public virtual ICollection<ARRelatedEmpEntity> ARRelatedEmpEntities { get; set; }
        public virtual ICollection<WriteOffEntity> WriteOffEntities { get; set; }
    }
}
