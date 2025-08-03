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
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("3 karakterden az giriş yapamazsınız");
            RuleFor(x => x.HeadingName).MaximumLength(100).WithMessage("100 karakterden fazla giriş yapamazsınız");
        }
    }
}

