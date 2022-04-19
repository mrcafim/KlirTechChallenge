using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Commands
{
    public class UpdateProductPromotionCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int MinimumQuantity { get; set; }
        public decimal Discount { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductPromotionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
