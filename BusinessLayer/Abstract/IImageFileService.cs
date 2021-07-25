using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        ImageFile GetById(int id);
        void AddImageFile(ImageFile imageFile);
        void DeleteImageFile(ImageFile imageFile);
        void UpdateImageFile(ImageFile imageFile);
    }
}
