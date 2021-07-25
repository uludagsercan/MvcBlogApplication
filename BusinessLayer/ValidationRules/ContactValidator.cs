using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanını boş geçemezsiniz");
            RuleFor(x => x.Message).MaximumLength(255).WithMessage("En fazla 255 karakter girebilirsiniz");
            RuleFor(x => x.Message).MinimumLength(3).WithMessage("En az 3 karakter girebilirsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter girebilirsiniz");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girebilirsiniz");
            RuleFor(x => x.UserMail).MaximumLength(50).WithMessage("En falza 50 karakter girebilirsiniz");
            
        }
    }
}
