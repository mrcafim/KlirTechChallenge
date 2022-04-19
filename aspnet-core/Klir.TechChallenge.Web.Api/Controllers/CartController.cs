using Klir.TechChallenge.Web.Domain.Cart.Commands;
using Klir.TechChallenge.Web.Domain.Cart.Repositories;
using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("cart")]
    public class CartController : BaseController
    {
        private readonly ICartRepository _cartRepository;

        public CartController
        (
            ICartRepository cartRepository,
            IProductPromotionRepository productPromotionRepository,
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        ) : base(notifications, bus)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public Task<IActionResult> GetByCart(Guid id)
        {
            var result = _cartRepository.GetByCart(id);
            return Response(result);
        }

        [HttpPost]
        public Task<IActionResult> Post([FromBody] AddCartCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] UpdateCartCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }
    }
}
