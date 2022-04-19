using Klir.TechChallenge.Web.Domain.Cart.Validations;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands
{
    public class AddCartCommand : Command
    {
        public Guid UserId { get; set; }
        public IEnumerable<AddCartItemCommand> Items { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddCartValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
