using Klir.TechChallenge.Web.Domain.Core.Commands;
using MediatR;

namespace Klir.TechChallenge.Web.Domain.Core.Events
{
    public abstract class Message : IRequest<CommandResult>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
