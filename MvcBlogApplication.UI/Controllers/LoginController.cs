using BusinessLayer.Concrete;
using BusinessLayer.CryptoHelpers;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MvcBlogApplication.UI.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        AdminValidator av = new AdminValidator();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Login login = new Login();
            
            var userList = am.GetList();
            if (userList.Count == 0)
            {

                admin.AdminRole = "A";
                login.SavePassword(admin);
                ViewBag.Message = "Admin Kullanıcı Bilgileri Oluşturuldu";
                return View();
            }

            ValidationResult validationResult = av.Validate(admin);
            //var adminuserinfo
            if (validationResult.IsValid)
            {
                
                if (login.CheckPassword(admin))
                {
                    //Yönlendirme işlemleri
                    FormsAuthentication.SetAuthCookie(admin.AdminUserName, false);
                    Session["AdminUserName"] = admin.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
        }
    }
}