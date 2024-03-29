﻿using FluentValidation;
using Klir.TechChallenge.Web.Domain.User.Commands;

namespace Klir.TechChallenge.Web.Domain.User.Validations
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type is required")
                .IsInEnum().WithMessage("Invalid type");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
