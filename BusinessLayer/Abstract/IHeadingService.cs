using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        int FindCategoryById(int id);
        String GetMaxCategory();
        int GetCategoryCount();
        void HeadingAdd(Heading heading);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
        List<Heading> GetList();
        Heading GetById(Heading heading);
        Heading GetById(int id);
    }
}
