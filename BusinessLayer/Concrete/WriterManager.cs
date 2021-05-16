using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
    }
}
