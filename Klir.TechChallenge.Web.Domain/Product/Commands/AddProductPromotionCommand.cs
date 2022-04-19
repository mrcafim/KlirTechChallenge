using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Validations;
using System;

namespace Klir.TechChallenge.Web.Domain.Product.Commands
{
    public class AddProductPromotionCommand : Command
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int MinimumQuantity { get; set; }
        public decimal Discount { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddProductPromotionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
