﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçmeyiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını Boş Geçmeyiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapınız");

        }

    }
}
