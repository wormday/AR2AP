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
    
    public partial class ARRelatedEmpEntity
    {
        public int ID { get; set; }
        public int ARID { get; set; }
        public short EmpID { get; set; }
    
        public virtual AREntity AREntity { get; set; }
        public virtual EmpEntity EmpEntity { get; set; }
    }
}
