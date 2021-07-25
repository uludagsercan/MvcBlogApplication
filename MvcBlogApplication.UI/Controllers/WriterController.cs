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
    public class WriterController : Controller
    {
        // GET: AdminWriter
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View(wm.GetListBl());
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid)
            {
                wm.SetWriter(writer);
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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            return View(wm.GetByIdBl(id));
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            wm.WriterUpdate(p);
            return RedirectToAction("Index");
        }
    }
}