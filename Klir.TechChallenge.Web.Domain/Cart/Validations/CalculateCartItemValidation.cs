﻿using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class CalculateCartItemValidation : AbstractValidator<CalculateCartItemCommand>
    {
        public CalculateCartItemValidation()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is required");
        }
    }
}
