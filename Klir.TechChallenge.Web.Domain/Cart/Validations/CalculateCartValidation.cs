using FluentValidation;
using Klir.TechChallenge.Web.Domain.Cart.Commands;

namespace Klir.TechChallenge.Web.Domain.Cart.Validations
{
    public class CalculateCartValidation : AbstractValidator<CalculateCartCommand>
    {
        public CalculateCartValidation()

        {
        }
    }
}
