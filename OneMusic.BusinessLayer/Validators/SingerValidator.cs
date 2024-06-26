﻿using FluentValidation;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Validators
{
    public class SingerValidator:AbstractValidator<Singer>
    {
        public SingerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Şarkıcı adı boş geçilemez").MaximumLength(50).WithMessage("50 karakterden fazla girmemelisiniz").MinimumLength(3).WithMessage("En az 3 karakter girmelisiniz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim url boş bırakılamaz"); 
        }
    }
}
