using FluentValidation;
using Klir.TechChallenge.Web.Domain.Product.Commands;

namespace Klir.TechChallenge.Web.Domain.Product.Validations
{
    public class UpdateProductPromotionValidation : AbstractValidator<UpdateProductPromotionCommand>
    {
        public UpdateProductPromotionValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required");

            RuleFor(x => x.MinimumQuantity)
                .NotEmpty().WithMessage("MinimumQuantity is required");

            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Discount is required");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

        }
    }
}
