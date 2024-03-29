﻿using FluentValidation;
using Klir.TechChallenge.Web.Domain.Product.Commands;

namespace Klir.TechChallenge.Web.Domain.Product.Validations
{
    public class AddProductValidation : AbstractValidator<AddProductCommand>
    {
        public AddProductValidation()
        {
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
        }
    }
}
