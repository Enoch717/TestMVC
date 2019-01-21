using MVC0117.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC0117.DAL
{
    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>()
            {
                new SysUser()
                {
                    UserName="Admin",
                    Password="123456",
                    Email="Alice@qq.com"
                   
                },
                new SysUser()
                {
                    UserName="Alice",
                    Password="123456",
                    Email="Alice@qq.com"
                },
                new SysUser()
                {
                    UserName="Ben",
                    Password="123456",
                    Email="Ben@qq.com"
                }
            };

            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();

            var sysRoles = new List<SysRole>()
            {
                new SysRole()
                {
                    RoleName="Administrator",
                    RoleDesc="Administrator have full authorization to perform system administration."
                },
                new SysRole()
                {
                    RoleName="General User",
                    RoleDesc="General User can access the data they are authorized for."
                }
            };

            sysRoles.ForEach(s => context.SysRoles.Add(s));
            context.SaveChanges();

            var SysUserRoles = new List<SysUserRole>()
            {
                new SysUserRole()
                {
                    ID=1,
                    SysUserID = 1,
                    SysRoleID = 1
                },
                new SysUserRole()
                {
                    ID=2,
                    SysUserID = 2,
                    SysRoleID = 2
                },
                new SysUserRole()
                {
                    ID=3,
                    SysUserID = 3,
                    SysRoleID = 2
                }
            };
            SysUserRoles.ForEach(s => context.SysUserRoles.Add(s));
            context.SaveChanges();

            //context.SysUsers.AddRange(users);
            //context.SysRole.AddRange(roles);
            //context.SaveChanges();
        }
    }
}