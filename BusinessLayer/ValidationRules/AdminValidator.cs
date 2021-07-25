using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator: AbstractValidator<Admin>
    {
        AdminManager am = new AdminManager(new EfAdminDal());
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName).Must(CheckUserName).WithMessage("Kullanıcı adı veya şife yanlış girilmiştir.");
            //RuleFor(x => x.AdminPassword).Must(ChekPassword).WithMessage("Kullanıcı adı veya şife yanlış girilmiştir.");            
        }
        private bool CheckUserName (string username)
        {
            var userList = am.GetList();
            if (username == null)
            {
                return false;
            }
            foreach (var item in userList)
            {
                if (username == item.AdminUserName)
                {
                    return true;
                }  
            }
            return false;
        }
        //private bool ChekPassword(string password)
        //{
        //    var userList = am.GetList();
        //    if (password == null)
        //    {
        //        return false;
        //    }
        //    foreach (var item in userList)
        //    {
        //        if (password == )
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
