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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }
        public void AddSkill(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillId == id);
        }

        public List<Skill> GetSkillByPerson(int id)
        {
            return _skillDal.List(x => x.PersonId == id);
        }
    }
}
