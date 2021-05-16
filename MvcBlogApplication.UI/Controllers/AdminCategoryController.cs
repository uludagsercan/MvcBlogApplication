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
        public ActionResult UpdateCategory(Category p,int id)
        {
            Category category = new Category();
            category = cm.GetCategory(id);
            category.CategoryName = p.CategoryName;
            category.CategoryDate = DateTime.Now;
            cm.UpdateCategoryBl(category);
            return RedirectToAction("Index");
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