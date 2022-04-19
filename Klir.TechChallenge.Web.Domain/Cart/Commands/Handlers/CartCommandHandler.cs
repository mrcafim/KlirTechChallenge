using Klir.TechChallenge.Web.Domain.Cart.Repositories;
using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Core.Transactions;
using Klir.TechChallenge.Web.Domain.User.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Domain.Cart.Commands.Handlers
{

    public class CartCommandHandler : CommandHandler,
        IRequestHandler<AddCartCommand, CommandResult>,
        IRequestHandler<UpdateCartCommand, CommandResult>,
        IRequestHandler<CalculateCartCommand, CommandResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;


        public CartCommandHandler
        (
            ICartRepository cartRepository,
            IUserRepository userRepository,
            IUnitOfWork uow,
            IBus bus,
            INotificationHandler<DomainNotification> notifications
        ) : base(uow, bus, notifications)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public Task<CommandResult> Handle(AddCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var user = _userRepository.GetById(command.UserId);

                if (user == null)
                {
                    RaiseDomainNotification(command.MessageType, "User not found");
                    return Task.FromResult(new CommandResult(false));
                }

                if (user.CartId != null)
                {
                    RaiseDomainNotification(command.MessageType, "There is already a cart for this user");
                    return Task.FromResult(new CommandResult(false));
                }

                var cart = new Entities.Cart();

                if (command.Items != null && command.Items.Any())
                {
                    foreach (var item in command.Items)
                    {
                        if (!ValidateCommand(item))
                            return Task.FromResult(new CommandResult(false));

                        cart.AddItem(item.ProductId, item.Quantity);
                    }
                }

                _cartRepository.Add(cart);

                return Task.FromResult(new CommandResult(InTransaction || Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var cart = _cartRepository.GetById(command.Id);

                if (cart == null)
                {
                    RaiseDomainNotification(command.MessageType, "Cart not found.");
                    return Task.FromResult(new CommandResult(false));
                }

                cart.ClearCart();

                if (command.Items != null && command.Items.Any())
                {
                    foreach (var item in command.Items)
                    {
                        if (!ValidateCommand(item))
                            return Task.FromResult(new CommandResult(false));

                        cart.AddItem(item.ProductId, item.Quantity);
                    }
                }

                _cartRepository.Update(cart);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(CalculateCartCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));


                var cart = _cartRepository.GetById(command.Id);

                if (cart == null)
                {
                    cart = new Entities.Cart();
                    cart.Id = command.Id;
                    foreach (var item in command.Items)
                    {
                        cart.AddItem(item.ProductId, item.Quantity);
                    }
                    _cartRepository.Add(cart);
                }
                else
                {
                    cart.ClearCart();
                    foreach (var item in command.Items)
                    {
                        cart.AddItem(item.ProductId, item.Quantity);
                    }
                    _cartRepository.Update(cart);
                }

                return Task.FromResult(new CommandResult(InTransaction || Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }
    }
}
