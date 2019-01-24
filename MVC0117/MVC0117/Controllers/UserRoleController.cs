﻿using MVC0117.DAL;
using MVC0117.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using MVC0117.Models;

namespace MVC0117.Controllers
{
    public class UserRoleController : Controller
    {

        private AccountContext db = new AccountContext();
        // GET: UserRole
        public ActionResult Index(int? id)
        {
            var viewModel = new UserRoleIndexData();
            viewModel.SysUsers = db.SysUsers
                .Include(u => u.SysDepartment)
                .Include(u => u.SysUserRoles.Select(ur => ur.SysRole))
                .OrderBy(u => u.UserName);

            if (id != null)
            {
                ViewBag.UserID = id.Value;
                viewModel.SysUserRoles = viewModel.SysUsers.Where(u => u.ID == id.Value).Single().SysUserRoles;
                viewModel.SysRoles = (viewModel.SysUserRoles.Where(
                    ur => ur.SysUserID == id.Value)).Select(ur => ur.SysRole);
            }
            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SysUser user = db.SysUsers
                .Include(u => u.SysDepartment)
                .Include(u => u.SysUserRoles)
                .Where(u => u.ID == id)
                .Single();
            //将用户所在的部门选出
            PopulateDepartmentsDropDownList(user.SysDepartmentID);

            //将某个用户下的所有角色取出
            PopulateAssignedRoleData(user);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string[] selectedRoles)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var userToUpdate = db.SysUsers.Include(u => u.SysUserRoles).Where(u => u.ID == id).Single();

            if (TryUpdateModel(userToUpdate, "",
                new string[] { "LoginName", "Email", "Password", "CreateDate", "SysDepartmentID" }))
            {
                try
                {
                    UpdateUserRoles(selectedRoles, userToUpdate);

                    db.Entry(userToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }

                catch (Exception)
                {
                    throw;
                }
            }
            return View(userToUpdate);
        }

        private void UpdateUserRoles(string[] selectedRoles, SysUser userToUpdate)
        {
            using (AccountContext db2 = new AccountContext())
            {
                if (selectedRoles == null)
                {
                    var sysUserRoles = db2.SysUserRoles.Where(u => u.SysUserID == userToUpdate.ID).ToList();
                    foreach (var item in sysUserRoles)
                    {
                        db2.SysUserRoles.Remove(item);
                    }
                    db2.SaveChanges();
                    return;
                }

                var selectedRolesHS = new HashSet<string>(selectedRoles);

                //原来的角色
                var userRoles = new HashSet<int>(userToUpdate.SysUserRoles.Select(r => r.SysRoleID));

                foreach (var item in db.SysRoles)
                {
                    if (selectedRolesHS.Contains(item.ID.ToString()))
                    {
                        if (!userRoles.Contains(item.ID))
                            userToUpdate.SysUserRoles.Add(new SysUserRole { SysUserID = userToUpdate.ID, SysRoleID = item.ID });

                    }
                    else
                    {
                        if (userRoles.Contains(item.ID)) //如果没被选中，原来用的药去除
                        {
                            SysUserRole sysUserRole = db2.SysUserRoles
                                .FirstOrDefault(ur => ur.SysRoleID == item.ID && ur.SysUserID == userToUpdate.ID);
                            db2.SysUserRoles.Remove(sysUserRole);
                            db2.SaveChanges();

                        }
                    }
                }
            }

        }


        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in db.SysDepartments
                                   orderby d.DepartmentName
                                   select d;
            ViewBag.SysDepartmentID = new SelectList(departmentsQuery, "ID", "DepartmentName", selectedDepartment);

        }

        private void PopulateAssignedRoleData(SysUser user)
        {
            var allRoles = db.SysRoles.ToList();
            //获取用户关联角色的id
            var userRoles = new HashSet<int>(user.SysUserRoles.Select(r => r.SysRoleID));
            var viewModel = new List<AssignedRoleData>();
            foreach (var role in allRoles)
            {
                viewModel.Add(new AssignedRoleData
                {
                    RoleId = role.ID,
                    RoleName = role.RoleName,
                    Assigned = userRoles.Contains(role.ID)
                });
            }
            ViewBag.Roles = viewModel;
        }
    }
}
