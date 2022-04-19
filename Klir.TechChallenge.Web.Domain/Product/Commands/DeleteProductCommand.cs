using Klir.TechChallenge.Web.Domain.Core.Commands;
using Klir.TechChallenge.Web.Domain.Product.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Commands
{
    public class DeleteProductCommand : Command
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
