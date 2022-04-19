using FluentValidation;
using Klir.TechChallenge.Web.Domain.User.Commands;

namespace Klir.TechChallenge.Web.Domain.User.Validations
{
    public class DeleteUserValidation : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
