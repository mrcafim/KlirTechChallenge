using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class CalculateCartValidation : AbstractValidator<CalculateCartCommand>
    {
        public CalculateCartValidation()

        {
        }
    }
}
