using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Validations;

namespace Klir.TechChallenge.Web.Domain.Product.Commands
{
    public class AddProductCommand : Command
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public AddProductPromotionCommand Promotion { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
