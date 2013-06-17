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
    
    /// <summary>Agency（本集团的相关公司）实体</summary>
    public partial class AgencyEntity
    {
        public AgencyEntity()
        {
            this.AREntities = new HashSet<AREntity>();
            this.CollectionEntities = new HashSet<CollectionEntity>();
        }
        public short AgencyID { get; set; }
        public string AgencyName { get; set; }
        public byte CurrencyType { get; set; }
    
        public virtual ICollection<AREntity> AREntities { get; set; }
        public virtual ICollection<CollectionEntity> CollectionEntities { get; set; }
    }
}
