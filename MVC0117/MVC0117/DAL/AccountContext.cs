using MVC0117.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC0117.DAL
{
    public class AccountContext : System.Data.Entity.DbContext
    {
        public AccountContext()
            : base("AccountContext")
        {

        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }

        public DbSet<SysRole> SysRoles { get; set; }

        public DbSet<SysUserRole> SysUserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public System.Data.Entity.DbSet<MVC0117.Models.SysDepartment> SysDepartments { get; set; }

    }
}