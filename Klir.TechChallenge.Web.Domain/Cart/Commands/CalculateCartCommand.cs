using Klir.TechChallenge.Web.Domain.Cart.Validations;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands
{
    public class CalculateCartCommand : Command
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public List<CalculateCartItemCommand> Items { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CalculateCartValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
