using System;
using System.Collections.Generic;
using System.Text;
using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Core.Transactions;
using Klir.TechChallenge.Web.Infra.Bus;
using Klir.TechChallenge.Web.Infra.Data.Context;
using Klir.TechChallenge.Web.Infra.Data.Transactions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Klir.TechChallenge.Web.Infra.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            // Bus
            RegisterBus(services);

            // Domain notifications
            RegisterDomainNotification(services);

            // Data
            RegisterDataContext(services);

            // Modules
            RegisterModules(services);
        }

        private static void RegisterBus(IServiceCollection services)
        {
            services.AddScoped<IBus, InMemoryBus>();
        }

        private static void RegisterDomainNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        private static void RegisterDataContext(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();
        }
        private static void RegisterModules(IServiceCollection services)
        {
            UserDependencyInjector.Register(services);
        }
    }
}
