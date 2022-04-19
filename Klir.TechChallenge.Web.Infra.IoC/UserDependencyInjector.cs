using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.User.Commands;
using Klir.TechChallenge.Web.Domain.User.Commands.Handlers;
using Klir.TechChallenge.Web.Domain.User.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Web.Infra.IoC
{
    public static class UserDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AddUserCommand, CommandResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, CommandResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, CommandResult>, UserCommandHandler>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
