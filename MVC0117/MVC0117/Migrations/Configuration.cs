namespace MVC0117.Migrations
{
    using MVC0117.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC0117.DAL.AccountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC0117.DAL.AccountContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
            //var sysUsers = new List<SysUser>
            //{
            //    new SysUser{UserName="Tom",Email="Tom@sohu.com",Password="1"},
            //    new SysUser{UserName="Jerry",Email="Jerry@sohu.com",Password="2"}
            //};
            //sysUsers.ForEach(s => context.SysUsers.AddOrUpdate(p => p.UserName, s));
            //context.SaveChanges();
            //var sysRoles = new List<SysRole>
            //{
            //    new SysRole{
            //        RoleName="Administrators",
            //        RoleDesc="Administrtors have full authorization to perform system administration."
            //    },
            //    new SysRole{RoleName="General Users",
            //        RoleDesc="General Users can access the shared data they are authorized for."
            //    }
            //};
            //sysRoles.ForEach(s => context.SysRoles.AddOrUpdate(r => r.RoleName, s));
            //context.SaveChanges();

            //var sysUserRoles = new List<SysUserRole>
            //{
            //    new SysUserRole{
            //        SysUserID=sysUsers.Single(s=>s.UserName=="Tom").ID,
            //        SysRoleID=sysRoles.Single(r=>r.RoleName=="Administrators").ID
            //    },
            //    new SysUserRole{
            //        SysUserID=sysUsers.Single(s=>s.UserName=="Tom").ID,
            //        SysRoleID=sysRoles.Single(r=>r.RoleName=="General Users").ID
            //    },
            //    new SysUserRole{
            //        SysUserID=sysUsers.Single(s=>s.UserName=="Jerry").ID,
            //        SysRoleID=sysRoles.Single(r=>r.RoleName=="General Users").ID
            //    }
            //};

            //foreach (SysUserRole item in sysUserRoles)
            //{
            //    var sysUserRoleInDataBase = context.SysUserRoles.Where(
            //        s =>
            //            s.SysUser.ID == item.SysUserID &&
            //            s.SysRole.ID == item.SysRoleID).SingleOrDefault();
            //    if (sysUserRoleInDataBase == null)
            //    {
            //        context.SysUserRoles.Add(item);
            //    }
            //}
            //context.SaveChanges();
        }
    }
}
