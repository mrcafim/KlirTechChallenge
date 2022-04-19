using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.User.Validations;
using System;

namespace Klir.TechChallenge.Web.Domain.User.Commands
{
    public class DeleteUserCommand : Command
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
