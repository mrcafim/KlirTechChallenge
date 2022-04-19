using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Commands
{
    public class UpdateProductCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AddProductPromotionCommand Promotion { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
