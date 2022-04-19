using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.User.Enums;
using Klir.TechChallenge.Web.Domain.User.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.User.Commands
{
    public class AddUserCommand : Command
    {
        public UserRole Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? Cart { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
