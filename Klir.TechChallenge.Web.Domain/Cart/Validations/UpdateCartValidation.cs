using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class UpdateCartValidation : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required");
        }
    }
}
