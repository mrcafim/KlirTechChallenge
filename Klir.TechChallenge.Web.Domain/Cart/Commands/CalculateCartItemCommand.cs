using Klir.TechChallenge.Web.Domain.Cart.Validations;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using System;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands
{
    public class CalculateCartItemCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string Promotion { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CalculateCartItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
