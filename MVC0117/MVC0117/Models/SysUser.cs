using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC0117.Models
{
    public class SysUser
    {
        public int ID { get; set; }
        [StringLength(10,ErrorMessage ="name cannot be longer than 10 characters")]
        [Column("LoginName")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime CreateDate { get; set; }

        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }

        public int? SysDepartmentID { get; set; }
        public virtual SysDepartment SysDepartment { get; set; }
    }
}