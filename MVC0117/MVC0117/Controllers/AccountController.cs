using MVC0117.DAL;
using MVC0117.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC0117.Controllers
{
    public class AccountController : Controller
    {
        private AccountContext db = new AccountContext();
        // GET: Account
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;
            //var users = from u in db.SysUsers
            //            select u;
            var users = db.SysUsers.Include(u => u.SysDepartment);

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                default:
                    users = users.OrderBy(u => u.UserName);
                    break;

            }
            int pagesize = 3;
            int pageNumber = (page ?? 1);

            return View(users.ToPagedList(pageNumber, pagesize));
        }


        public ActionResult Details(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }

        public ActionResult Login()
        {
            ViewBag.LoginState = "Before login...";
            return View();
        }


        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            //获取表单数据
            string email = fc["exampleInputEmail3"];
            string password = fc["exampleInputPassword3"];

            //进行下一步处理
            var user = db.SysUsers.Where(b => b.Email == email && b.Password == password);

            if (user.Count() > 0)
            {
                ViewBag.LoginState = email + " logined in ....";
            }
            else
                ViewBag.LoginState = email + " account does not exist...";

            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }



        //新建用户
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SysUser sysUser)
        {
            if (ModelState.IsValid)
            {
                sysUser.CreateDate = DateTime.Now;
                db.SysUsers.Add(sysUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //修改用户
        public ActionResult Edit(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }

        [HttpPost]
        public ActionResult Edit(SysUser sysUser)
        {
            db.Entry(sysUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //删除用户
        public ActionResult Delete(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            return View(sysUser);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SysUser sysUser = db.SysUsers.Find(id);
            db.SysUsers.Remove(sysUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}