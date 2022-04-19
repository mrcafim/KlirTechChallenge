using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Infra.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
