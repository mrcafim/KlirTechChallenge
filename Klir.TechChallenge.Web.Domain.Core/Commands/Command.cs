using FluentValidation.Results;
using Klir.TechChallenge.Web.Domain.Core.Events;
using System;

namespace Klir.TechChallenge.Web.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
