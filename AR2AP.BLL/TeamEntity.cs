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
    
    /// <summary>业务团队</summary>
    public partial class TeamEntity
    {
        public TeamEntity()
        {
            this.AREntities = new HashSet<AREntity>();
        }
        public short TeamID { get; set; }
        public string Market { get; set; }
        public string Depart { get; set; }
    
        public virtual ICollection<AREntity> AREntities { get; set; }
    }
}
