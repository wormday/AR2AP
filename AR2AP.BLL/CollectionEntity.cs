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
    
    public partial class CollectionEntity
    {
        public CollectionEntity()
        {
            this.WriteOffEntities = new HashSet<WriteOffEntity>();
        }
    
        public int CollectionID { get; set; }
        public Nullable<int> ClientID { get; set; }
        public string CollectionDate { get; set; }
        public int AgencyEntityAgencyID { get; set; }
        public string CollectionAmount { get; set; }
        public string CollectionRemark { get; set; }
    
        public virtual ClientEntity ClientEntity { get; set; }
        public virtual AgencyEntity AgencyEntity { get; set; }
        public virtual ICollection<WriteOffEntity> WriteOffEntities { get; set; }
    }
}
