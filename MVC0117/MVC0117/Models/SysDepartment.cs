using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC0117.Models
{
    public class SysDepartment
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDesc { get; set; }
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}