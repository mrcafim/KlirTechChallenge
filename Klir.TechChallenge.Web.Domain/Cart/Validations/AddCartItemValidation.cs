﻿using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class AddCartItemValidation : AbstractValidator<AddCartItemCommand>
    {
        public AddCartItemValidation()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
