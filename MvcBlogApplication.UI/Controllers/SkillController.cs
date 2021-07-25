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
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        PersonManager pm = new PersonManager(new EfPersonDal());
        // GET: Skill
        public ActionResult Index(int id)
        {
            return View(sm.GetSkillByPerson(id));
        }
        
        public ActionResult AddSkill()
        {
            List<SelectListItem> listPerson = (from p in pm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = p.PersonFullName,
                                                   Value = p.PersonId.ToString()
                                               }).ToList();
            ViewBag.listPerson = listPerson;
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            sm.AddSkill(skill);
            return View();
        }
       
    }
}