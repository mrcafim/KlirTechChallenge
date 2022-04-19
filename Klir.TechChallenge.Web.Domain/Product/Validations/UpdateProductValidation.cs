using FluentValidation;
using Klir.TechChallenge.Web.Domain.Product.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Validations
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
        }
    }
}
