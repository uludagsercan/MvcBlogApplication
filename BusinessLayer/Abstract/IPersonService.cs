using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonService
    {
        void AddPerson(Person p);
        List<Person> GetList();
        Person GetById(int id);
        void UpdatePerson(Person person);

    }
}
