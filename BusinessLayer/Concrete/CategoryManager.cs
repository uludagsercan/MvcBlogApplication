using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        private GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> ListCategory()
        {
            return repository.List();
        }
        
        public void CategoryAddBl(Category c)
        {
            if (c.CategoryName == "" || c.CategoryStatus == false || c.CategoryName.Length<=3 || c.CategoryName.Length>50)
            {
                //Error Message
            }
            else
            {
                repository.Insert(c);
            }
        }
    }
}
