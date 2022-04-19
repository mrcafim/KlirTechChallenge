using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Core.Transactions;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Domain.Product.Commands.Handlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<AddProductCommand, CommandResult>,
        IRequestHandler<DeleteProductCommand, CommandResult>,
        IRequestHandler<UpdateProductCommand, CommandResult>,
        IRequestHandler<AddProductPromotionCommand, CommandResult>,
        IRequestHandler<UpdateProductPromotionCommand, CommandResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPromotionRepository _productPromotionRepository;


        public ProductCommandHandler
        (
            IProductRepository productRepository,
            IProductPromotionRepository productPromotionRepository,
            IUnitOfWork uow,
            IBus bus,
            INotificationHandler<DomainNotification> notifications
        ) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            _productPromotionRepository = productPromotionRepository;
        }
        public Task<CommandResult> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var product = new Entities.Product
                (
                    command.Name,
                    command.Price,
                    command.Description
                );

                if (command.Promotion != null)
                    product.SetPromotion(command.Promotion.Description, command.Promotion.MinimumQuantity, command.Promotion.Discount);

                _productRepository.Add(product);

                return Task.FromResult(new CommandResult(InTransaction || Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var product = _productRepository.GetById(command.Id);

                if (product == null)
                {
                    RaiseDomainNotification(command.MessageType, "Product not found.");
                    return Task.FromResult(new CommandResult(false));
                }

                product.UpdateProduct
                (
                    command.Name,
                    command.Price,
                    command.Description
                );

                if (command.Promotion != null)
                    product.SetPromotion(command.Promotion.Description, command.Promotion.MinimumQuantity, command.Promotion.Discount);
                else
                    product.RemovePromotion();
                _productRepository.Update(product);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var product = _productRepository.GetById(command.Id);

                if (product == null)
                {
                    RaiseDomainNotification(command.MessageType, "Product not found");
                    return Task.FromResult(new CommandResult(false));
                }

                product.Delete();

                _productRepository.Update(product);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(AddProductPromotionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));


                var product = _productRepository.GetById(command.ProductId);

                if (product == null)
                {
                    RaiseDomainNotification(command.MessageType, "Product not found");
                    return Task.FromResult(new CommandResult(false));
                }

                if (product.Promotion != null)
                {
                    RaiseDomainNotification(command.MessageType, "There is already a promotion for this product");
                    return Task.FromResult(new CommandResult(false));
                }


                var promotion = new Entities.ProductPromotion
                (
                    command.ProductId,
                    command.Description,
                    command.MinimumQuantity,
                    command.Discount
                );

                _productPromotionRepository.Add(promotion);

                return Task.FromResult(new CommandResult(InTransaction || Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(UpdateProductPromotionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var promotion = _productPromotionRepository.GetById(command.Id);

                if (promotion == null)
                {
                    RaiseDomainNotification(command.MessageType, "Promotion not found.");
                    return Task.FromResult(new CommandResult(false));
                }

                promotion.UpdatePromotion
                (
                    command.Description,
                    command.MinimumQuantity,
                    command.Discount
                );

                _productPromotionRepository.Update(promotion);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }
    }
}
