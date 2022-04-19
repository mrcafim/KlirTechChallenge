using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly IBus Bus;

        protected BaseController
        (
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        )
        {
            _notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected new async Task<IActionResult> Response(object result = null)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (IsValid())
            {
                return Ok(result);
            }

            return BadRequest(_notifications.GetNotifications().Select(n => n.Value));
        }
    }
}
