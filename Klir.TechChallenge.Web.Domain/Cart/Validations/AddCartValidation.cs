using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class AddCartValidation : AbstractValidator<AddCartCommand>
    {
        public AddCartValidation()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required");
        }
    }
}
