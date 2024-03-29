﻿using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.User.Enums;
using Klir.TechChallenge.Web.Domain.User.Validations;
using System;

namespace Klir.TechChallenge.Web.Domain.User.Commands
{
    public class UpdateUserCommand : Command
    {
        public Guid Id { get; set; }
        public UserRole Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? Cart { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
