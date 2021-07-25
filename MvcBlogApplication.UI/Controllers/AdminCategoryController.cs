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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
                       
            var categoryList = cm.GetCategoryList();
            return View(categoryList);
        }
        [HttpPost]
        public ActionResult DeleteCategory(Category p)
        {
            p=cm.GetCategory(p);
            cm.DeleteCategoryBl(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            return View(cm.GetCategory(id));
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(p);
            if (validationResult.IsValid)
            {
                p.CategoryDate = DateTime.Now;
                cm.UpdateCategoryBl(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(cm.GetCategory(p));
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = false;
                p.CategoryDate = DateTime.Now;
                cm.SetCategory(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}