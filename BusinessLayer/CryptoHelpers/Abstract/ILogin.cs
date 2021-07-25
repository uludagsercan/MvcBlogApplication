using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CryptoHelpers.Abstract
{
    public interface ILogin
    {
        void SavePassword(Admin admin);
        bool CheckPassword(Admin admin);
    }
}
