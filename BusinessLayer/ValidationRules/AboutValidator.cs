using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails1).MinimumLength(3).WithMessage("En az 3 karakter girişi yapabilirsiniz");
            RuleFor(x => x.AboutDetails2).MinimumLength(3).WithMessage("En az 3 karakter girişi yapabilirsiniz");
            RuleFor(x => x.AboutDetails1).MaximumLength(1000).WithMessage("En fazla 1000 karakter girişi yapabilirsiniz");
            RuleFor(x => x.AboutDetails2).MaximumLength(1000).WithMessage("En fazla 1000 karakter girişi yapabilirsiniz");
            RuleFor(x => x.AboutDetails1).NotEmpty().WithMessage("Hakkında alanı boş geçilemez");
            RuleFor(x => x.AboutDetails2).NotEmpty().WithMessage("Hakkında alanı boş geçilemez");
        }
    }
}
