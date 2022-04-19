using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Product.Commands;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("product")]
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPromotionRepository _productPromotionRepository;

        public ProductController
        (
            IProductRepository productRepository,
            IProductPromotionRepository productPromotionRepository,
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        ) : base(notifications, bus)
        {
            _productRepository = productRepository;
            _productPromotionRepository = productPromotionRepository;
        }

        [HttpGet]
        public Task<IActionResult> GetProduct()
        {
            var result = _productRepository.GetProduct();
            return Response(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public Task<IActionResult> GetByProduct(Guid id)
        {
            var result = _productRepository.GetByProduct(id);
            return Response(result);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddProductCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] UpdateProductCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };

            Bus.SendCommand(command);
            return Response();
        }

        [HttpPost]
        [Route("promotion")]
        public Task<IActionResult> AddPromotion([FromBody] AddProductPromotionCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpPut]
        [Route("promotion")]
        public Task<IActionResult> UpdatePromotion([FromBody] UpdateProductPromotionCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }
    }
}
