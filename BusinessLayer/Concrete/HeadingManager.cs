using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            this.headingDal = headingDal;
        }
        public int FindCategoryById(int id)
        {
            return headingDal.List(x => x.CategoryId == id).Count;
        }

        public string GetMaxCategory()
        {
            var maxCategory = headingDal.List();
            var result = maxCategory.GroupBy(x => new { x.CategoryId, x.Category.CategoryName })
                .Select(x => new
                {
                    x.Key,
                    Count = x.Count()
                }).OrderByDescending(x => x.Count).First();

            return result.Key.CategoryName;

        }//En fazla başlığa sahip katagori adı..

        public int GetCategoryCount()
        {
            var headingList = headingDal.List();
            var result = headingList.GroupBy(x => new { x.CategoryId, x.Category.CategoryName })
                .Select(x => new { x.Key, Count = x.Count() }).FirstOrDefault(x => x.Key.CategoryName == "Yazılım"); return result.Count;
        }//Başlık tablosunda yazılım kategorisine ait başlık sayısı

        public void HeadingAdd(Heading heading)
        {
            headingDal.Insert(heading);
        }

        public void DeleteHeading(Heading heading)
        {
            headingDal.Update(heading);
        }

        public void UpdateHeading(Heading heading)
        {
            headingDal.Update(heading);
        }

        public List<Heading> GetList()
        {
            return headingDal.List();
        }

        public Heading GetById(Heading heading)
        {
            return headingDal.Get(x => x.HeadingId == heading.HeadingId);
        }
        public Heading GetById(int id)
        {
            return headingDal.Get(x => x.HeadingId == id);
        }
    }
}
