using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        Content GetById(int id);
        Content GetById(Content content);
        List<Content> GetListByHeadingID(int id);
        void AddContent(Content content);
        void DeleteContent(Content content);
        void UpdateContent(Content content);

    }
}
