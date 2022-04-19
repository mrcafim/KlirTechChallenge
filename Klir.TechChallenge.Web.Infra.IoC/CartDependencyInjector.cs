using Klir.TechChallenge.Web.Domain.Cart.Commands;
using Klir.TechChallenge.Web.Domain.Cart.Commands.Handlers;
using Klir.TechChallenge.Web.Domain.Cart.Repositories;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Infra.IoC
{
    public static class CartDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AddCartCommand, CommandResult>, CartCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCartCommand, CommandResult>, CartCommandHandler>();
            services.AddScoped<IRequestHandler<CalculateCartCommand, CommandResult>, CartCommandHandler>();

            // Repositories
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
        }
    }
}
