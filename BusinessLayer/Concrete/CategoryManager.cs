using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        
        ICategoryDal categoryDal;
      
        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetCategoryList()
        {

            return categoryDal.List();
            
        }
        
        public void DeleteCategoryBl(Category p)
        {
            categoryDal.Delete(p);
        }
        public void SetCategory(Category p)
        {
            categoryDal.Insert(p);
           
        }

        public Category GetCategory(Category p)
        {
            return categoryDal.Get(x => x.CategoryId == p.CategoryId);
        }
      
        public Category GetCategory(int id)
        {
            return categoryDal.Get(x => x.CategoryId == id);
        }
        public void UpdateCategoryBl(Category p)
        {
            
            categoryDal.Update(p);
        }

        public int FindCategory(string categoryName)
        {
            return categoryDal.Find(x => x.CategoryName == categoryName).CategoryId;
        }
       

        public int DifferenceStatus()
        {
            var result1 = categoryDal.List(x => x.CategoryStatus == false).Count();
            var result2 = categoryDal.List(x => x.CategoryStatus == true).Count();
            var difference = result1 < result2 ? result2 - result1 : result1 - result2;
            return difference;

        }
    }
}
