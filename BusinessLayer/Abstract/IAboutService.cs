using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        About GetAbout(int id);
        void DeleteAbout(About about);
        void UpdateAbout(About about);
        void AddAbout(About about);
    }
}
