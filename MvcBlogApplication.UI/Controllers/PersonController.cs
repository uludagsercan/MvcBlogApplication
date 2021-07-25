using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApplication.UI.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        PersonManager pm = new PersonManager(new EfPersonDal());
        public ActionResult Index()
        {

            return View(pm.GetList());
        }
        [HttpGet]
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            pm.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}