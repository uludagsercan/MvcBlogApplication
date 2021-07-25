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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
        public Admin Get(Admin admin)
        {
            return _adminDal.Get(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        }

        public Admin Get(string username)
        {
            return _adminDal.Get(x => x.AdminUserName == username);
        }
        public void AddAdmin(Admin admin)
        {
            _adminDal.Insert(admin);
        }
    }
}
