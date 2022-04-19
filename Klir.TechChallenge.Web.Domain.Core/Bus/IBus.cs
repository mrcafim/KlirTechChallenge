using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Core.Events;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Domain.Core.Bus
{
    public interface IBus
    {
        Task<CommandResult> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
