using Klir.TechChallenge.Web.Domain.Cart.Validations;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands
{
    public class AddCartItemCommand : Command
    {
        public Guid ProductId { get; protected set; }
        public int Quantity { get; private set; }
        public decimal DiscountAmount { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new AddCartItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
