using FluentValidation;
using Klir.TechChallenge.Web.Domain.Product.Commands;

namespace Klir.TechChallenge.Web.Domain.Product.Validations
{
    public class AddProductPromotionValidation : AbstractValidator<AddProductPromotionCommand>
    {
        public AddProductPromotionValidation()
        {
            RuleFor(x => x.MinimumQuantity)
                .NotEmpty().WithMessage("MinimumQuantity is required");

            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Discount is required");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

        }
    }
}
