using Klir.TechChallenge.Web.Domain.Core.Bus;
using Klir.TechChallenge.Web.Domain.Core.Notifications;
using Klir.TechChallenge.Web.Domain.User.Commands;
using Klir.TechChallenge.Web.Domain.User.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("user")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;

        public UserController
        (
            IUserRepository userRepository,
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        ) : base(notifications, bus)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public Task<IActionResult> GetUser()
        {
            var result = _userRepository.GetUser();
            return Response(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public Task<IActionResult> GetByUser(Guid id)
        {
            var result = _userRepository.GetByUser(id);
            return Response(result);
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddUserCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id };

            Bus.SendCommand(command);
            return Response();
        }
    }
}
