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
    public class HeadingController : Controller
    {
        // GET: AdminHeader
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            
            return View(hm.GetList());
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> listCategoryName = (from h in cm.GetCategoryList()
                                                select new SelectListItem
                                                {
                                                    Text = h.CategoryName,
                                                    Value = h.CategoryId.ToString()
                                                }).ToList();
            List<SelectListItem> listWriterName = (from w in wm.GetListBl()
                                                   select new SelectListItem
                                                   {
                                                       Text = w.WriterName,
                                                       Value = w.WriterId.ToString()
                                                   }).ToList();
            ViewBag.vlc = listCategoryName;
            ViewBag.writer = listWriterName;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            HeadingValidator headingValidation = new HeadingValidator();
            ValidationResult validationResult = headingValidation.Validate(heading);
            if (validationResult.IsValid)
            {
                heading.HeadingDate = DateTime.Now;
                hm.HeadingAdd(heading);
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
        [HttpGet]
        public ActionResult UpdateHeading (int id)
        {
            var updateHeading = hm.GetById(id);
            List<SelectListItem> listCategoryName = (from h in cm.GetCategoryList()
                                                     select new SelectListItem
                                                     {
                                                         Text = h.CategoryName,
                                                         Value = h.CategoryId.ToString()
                                                     }).ToList();
            List<SelectListItem> listWriterName = (from w in wm.GetListBl()
                                                   select new SelectListItem
                                                   {
                                                       Text = w.WriterName,
                                                       Value = w.WriterId.ToString()
                                                   }).ToList();
            ViewBag.vlc = listCategoryName;
            ViewBag.writer = listWriterName;
            return View(updateHeading);
        }
        [HttpPost]
        public ActionResult UpdateHeading (Heading heading)
        {
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult validationResult = validationRules.Validate(heading);
            if (validationResult.IsValid)
            {
                hm.UpdateHeading(heading);
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
       
        public ActionResult DeleteHeading (int id)
        {
            var headingValue = hm.GetById(id);
            if (headingValue.HeadingStatus)
                headingValue.HeadingStatus = false;
            else
                headingValue.HeadingStatus = true;
            hm.DeleteHeading(headingValue);
            return RedirectToAction("Index");
        }

        
    }
}