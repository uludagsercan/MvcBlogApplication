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
    
    public class CategoryController : Controller
    {
        // GET: Category
        
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
       
        
        [HttpGet]
        public ActionResult Index()
        {       
            
            return View(cm.GetCategoryList());
        }
        //[HttpPost]
        //public ActionResult Index(int? id)
        //{
        //    foreach (Category item in cm.ListCategory(id))
        //    {
        //        cm.DeleteCategory(item);
        //    }           
        //    return RedirectToAction("Index");
        //}

        //public ActionResult UpdateCategory(int? id)
        //{
        //    //foreach (Category item in cm.ListCategory(id))
        //    //{
        //    //   // cm.UpdateCategory(item);
        //    //}

        //    return View(c);
        //}
        //[HttpPost]
        //public ActionResult UpdateCategory(Category p, int? id)
        //{
        //    c = cm.FindCategory (id);
        //    c.CategoryName = p.CategoryName;
        //    cm.UpdateCategory(c);
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(p);
            if (validationResult.IsValid)
            {
                p.CategoryDate = DateTime.Now;
                cm.SetCategory(p);
                return RedirectToAction("Index");
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