using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz.");
            
            RuleFor(x => x.MessageSubject).MaximumLength(50).WithMessage("Konu alanı en fazla 50 karakterlidir");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("Alıcı alanı en fazla 50 karakterlidir");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Konu alanı en az 3 karakterlidir");
            RuleFor(x => x.ReceiverMail).Must(CheckEmail).WithMessage("Lütfen alıcı mailini düzgün girdiğinizden emin olunuz ve alıcı mail adresi boş geçilemez");


        }
        private bool CheckEmail (string email)
        {
            if (email==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
