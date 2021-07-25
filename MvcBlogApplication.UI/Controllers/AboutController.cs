using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApplication.UI.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            return View(am.GetList());
        }
        [HttpPost]
        public ActionResult AboutStatus(int id)
        {
            var getAbout = am.GetAbout(id);
            getAbout.AboutStatus = getAbout.AboutStatus == true ? false : true;
            am.UpdateAbout(getAbout);
            return RedirectToAction("Index");
        }
           
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult validationResult = validationRules.Validate(about);
            if (validationResult.IsValid)
            {
                am.AddAbout(about);
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}