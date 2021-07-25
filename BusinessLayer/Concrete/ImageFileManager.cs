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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageDal;
        public ImageFileManager(IImageFileDal imageFile)
        {
            _imageDal = imageFile;
        }
        public void AddImageFile(ImageFile imageFile)
        {
            _imageDal.Insert(imageFile);
        }

        public void DeleteImageFile(ImageFile imageFile)
        {
            _imageDal.Delete(imageFile);
        }

        public ImageFile GetById(int id)
        {
            return _imageDal.Get(x => x.ImageId == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageDal.List();
        }

        public void UpdateImageFile(ImageFile imageFile)
        {
            _imageDal.Update(imageFile);
        }
    }
}
