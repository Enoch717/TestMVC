using MVC0117.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC0117.ViewModels
{
    public class UserRoleIndexData
    {
        public IEnumerable<SysUser> SysUsers { get; set; }
        public IEnumerable<SysUserRole> SysUserRoles { get; set; }
        public IEnumerable<SysRole> SysRoles { get; set; }
    }
}