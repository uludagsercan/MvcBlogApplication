using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık ismi boş geçilemez");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Başlık alanı en az 3 karakter olmak zorundadır");
            RuleFor(x => x.HeadingName).MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakter olmak zorundadır.");
        }   
    }
}
