using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşmak zorundadır.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakterden oluşmak zorundadır.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklama alanı boş geçilemez");
            RuleFor(x => x.CategoryDescription).MinimumLength(8).WithMessage("Kategori açıklama alanı en az 8 karakter olmak zorundadır");
            RuleFor(x => x.CategoryDescription).MaximumLength(255).WithMessage("Kategori açıklama alanı en fazla 255 karakter olmak zorundadır");
        }
    }
}
