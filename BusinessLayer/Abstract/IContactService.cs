using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void UpdateContact(Contact contact);
        void AddContact(Contact contact);
        void DeleteContact(Contact contact);
        Contact GetById(int id);
        Contact GetById(Contact contact);

        
    }
}
