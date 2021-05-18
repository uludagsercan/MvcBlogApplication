using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        int GetContainsA();
        List<Writer> GetListBl();
        Writer GetByIdBl(Writer writer);
        void SetWriter(Writer writer); 
        void WriterUpdate(Writer writer);
        void WriterDelete(Writer writer);
    }
}
