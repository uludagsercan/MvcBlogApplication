using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApplication.UI.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            Dictionary<String, String> statisticResult = new Dictionary<string, string>();
            statisticResult.Add("CategoryCount", cm.GetCategoryList().Count.ToString());
            statisticResult.Add("GetCategoryCount", hm.GetCategoryCount().ToString());
            statisticResult.Add("GetContainsA", wm.GetContainsA().ToString());
            statisticResult.Add("MaxCategory", hm.GetMaxCategory());
            statisticResult.Add("DifferenceStatus", cm.DifferenceStatus().ToString());
            return View(statisticResult);
        }
    }
}