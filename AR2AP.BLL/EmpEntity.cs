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
    
    /// <summary>员工实体</summary>
    public partial class EmpEntity
    {
        public EmpEntity()
        {
            this.ARRelatedEmpEntities = new HashSet<ARRelatedEmpEntity>();
        }
        /// <summary>员工编号</summary>
        public short EmpID { get; set; }
        /// <summary>员工姓名</summary>
        public string EmpName { get; set; }
        /// <summary>员工电子邮件</summary>
        public string EmpEmail { get; set; }
        /// <summary>登陆本系统的用户名</summary>
        public string Username { get; set; }
        /// <summary>登陆本系统的密码</summary>
        public string Password { get; set; }
    
        public virtual ICollection<ARRelatedEmpEntity> ARRelatedEmpEntities { get; set; }
    }
}
