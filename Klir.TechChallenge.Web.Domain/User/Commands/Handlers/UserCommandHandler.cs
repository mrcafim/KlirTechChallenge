using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.Core.Transactions;
using Klir.TechChallenge.Web.Domain.User.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Domain.User.Commands.Handlers
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<AddUserCommand, CommandResult>,
        IRequestHandler<DeleteUserCommand, CommandResult>,
        IRequestHandler<UpdateUserCommand, CommandResult>
    {
        private readonly IUserRepository _userRepository;

        public UserCommandHandler
        (
            IUserRepository userRepository,
            IUnitOfWork uow,
            IBus bus,
            INotificationHandler<DomainNotification> notifications
        ) : base(uow, bus, notifications)
        {
            _userRepository = userRepository;
        }
        public Task<CommandResult> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                if (_userRepository.EmailExists(command.Email))
                {
                    RaiseDomainNotification(command.MessageType, "Email not valid. It's already in use.");
                    return Task.FromResult(new CommandResult(false));
                }

                var user = new Entities.User
                (
                    command.Type,
                    command.Name,
                    command.Email,
                    command.Password
                );

                if (command.Cart != null)
                    user.SetCartId(command.Cart);

                _userRepository.Add(user);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var user = _userRepository.GetById(command.Id);

                if (user == null)
                {
                    RaiseDomainNotification(command.MessageType, "User not found");
                    return Task.FromResult(new CommandResult(false));
                }

                user.Delete();
                user.Deactivate();

                _userRepository.Update(user);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var user = _userRepository.GetById(command.Id);

                if (user == null)
                {
                    RaiseDomainNotification(command.MessageType, "User not found.");
                    return Task.FromResult(new CommandResult(false));
                }

                if (_userRepository.UserExists(command.Email, command.Id))
                {
                    RaiseDomainNotification(command.MessageType, "Email is already in use by another user.");
                    return Task.FromResult(new CommandResult(false));
                }

                user.UpdateUser
                (
                    command.Type,
                    command.Name,
                    command.Email,
                    command.Password
                );

                if (command.Cart != null)
                    user.SetCartId(command.Cart);

                _userRepository.Update(user);

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
