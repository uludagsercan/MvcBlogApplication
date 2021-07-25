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
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }
        public int  GetContainsA()
        {
            return writerDal.List(x => x.WriterName.Contains("a")).Count;
        }
        public List<Writer> GetListBl()
        {
            return writerDal.List();
        }
        public Writer GetByIdBl(Writer writer)
        {
            return writerDal.Get(x => x.WriterId == writer.WriterId);
        }
        public Writer GetByIdBl(int id)
        {
            return writerDal.Get(x => x.WriterId == id);
        }
        public void WriterDelete(Writer writer)
        {
            writerDal.Delete(writer);
        }
        public void WriterUpdate(Writer writer)
        {
            writerDal.Update(writer);
        }
        public void SetWriter(Writer writer)
        {
            writer.WriterDate = DateTime.Now;
            writerDal.Insert(writer);
        }

        
    }
}
