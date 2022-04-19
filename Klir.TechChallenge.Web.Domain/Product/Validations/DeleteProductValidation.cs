using FluentValidation;
using Klir.TechChallenge.Web.Domain.Product.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Validations
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
