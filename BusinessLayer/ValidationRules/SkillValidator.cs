using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            //RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            //RuleFor(x => x.FullName).MinimumLength(3).WithMessage("İsim alanı en az 3 karakterden oluşmak zorundadır");
            //RuleFor(x => x.FullName).MaximumLength(60).WithMessage("İsim alanı en fazla 60 karakterden oluşmak zorundadır");
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek alanı boş geçilemez");
            RuleFor(x => x.SkillName).MinimumLength(3).WithMessage("Yetenek alanı en az 3 karater olmalıdır");
            RuleFor(x => x.SkillName).MaximumLength(50).WithMessage("Yetenek alanı en fazla 50 karakter olmak zorundadır");
        }
    }
}
