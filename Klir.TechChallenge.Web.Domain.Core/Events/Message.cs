using Klir.TechChallenge.Web.Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
