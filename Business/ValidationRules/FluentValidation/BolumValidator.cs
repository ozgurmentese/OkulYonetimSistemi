using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BolumValidator:AbstractValidator<Bolum>
    {
        public BolumValidator()
        {
            RuleFor(b => b.BolumAd).NotEmpty();
        }
    }
}
