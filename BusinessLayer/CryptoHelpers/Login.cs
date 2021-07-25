using BusinessLayer.Concrete;
using BusinessLayer.CryptoHelpers.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BusinessLayer.CryptoHelpers
{
    public class Login : ILogin
    {
        AdminManager am = new AdminManager(new EfAdminDal());

        public bool CheckPassword(Admin admin)
        {
            var checkUser = am.Get(admin.AdminUserName);
            return Crypto.VerifyHashedPassword(checkUser.AdminPassword,admin.AdminPassword);
        }

        public void SavePassword(Admin admin)
        {
            admin.AdminPassword = Crypto.HashPassword(admin.AdminPassword);
            
            am.AddAdmin(admin);
        }
    }
}
