using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        void SetCategory(Category p);
        Category GetCategory(Category p);
        Category GetCategory(int id);
        void DeleteCategoryBl(Category p);
        void UpdateCategoryBl(Category p);
        int DifferenceStatus();
        
    }
}
