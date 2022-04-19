using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Commands;
using Klir.TechChallenge.Web.Domain.Product.Commands.Handlers;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Web.Infra.IoC
{
    public static class ProductDependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Commands
            services.AddScoped<IRequestHandler<AddProductCommand, CommandResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, CommandResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, CommandResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<AddProductPromotionCommand, CommandResult>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductPromotionCommand, CommandResult>, ProductCommandHandler>();

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductPromotionRepository, ProductPromotionRepository>();
        }
    }
}
