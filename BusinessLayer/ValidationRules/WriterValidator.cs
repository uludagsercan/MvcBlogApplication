using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar ismi alanı boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar ismi alanı en az 2 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar ismi alanı en fazla 50 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı alanı boş geçilemez");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı alanı en az 2 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Yazar soyadı alanı en fazla 50 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifresi alanı boş geçilemez");
            RuleFor(x => x.WriterPassword).MaximumLength(6).WithMessage("Yazar şifre alanı en az 6 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterPassword).MaximumLength(16).WithMessage("Yazar şifre alanı en fazla 16 karakterden oluşmak zorundadır");
            RuleFor(x => x.WriterAbout).NotEmpty().Must(CheckAbout).WithMessage("Yazar hakkında alanında mutlaka 'a' harfi geçmesi zorunludur");
            RuleFor(x => x.WriterEmail).Must(CheckEmail).WithMessage("Yazar email alanı hatalı girilmiştir veya boş geçilmiştir. ");
            
            
            
        }
        private bool CheckAbout(string about)
        {
            var status = false;
            if (about == null)
            {
                return status;
            }
            else if (about.Contains("a"))
                return status = true;
            else
                return status;
        }
        private bool CheckEmail(string email)
        {
            var status = false;
            if (email == null)
            {
                return status;
            }
            else if (email.Contains("@"))
                return status = true;
            else
                return status;
        }
    }
}
