using Klir.TechChallenge.Web.Domain.Cart.Validations;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands
{
    public class UpdateCartCommand : Command
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<AddCartItemCommand> Items { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCartValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
