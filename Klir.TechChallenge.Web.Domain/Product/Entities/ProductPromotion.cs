using Klir.TechChallenge.Web.Domain.Core.Entities;
using System;

namespace Klir.TechChallenge.Web.Domain.Product.Entities
{
    public class ProductPromotion : Entity
    {
        protected ProductPromotion() { }

        public ProductPromotion(Guid productId, string description, int minimumQuantity, decimal discount)
        {
            ProductId = productId;
            Description = description;
            MinimumQuantity = minimumQuantity;
            Discount = discount;
            Active = true;
        }

        public Guid ProductId { get; protected set; }
        public string Description { get; private set; }
        public int MinimumQuantity { get; set; }
        public decimal Discount { get; private set; }
        public bool Active { get; private set; }

        public void Deactivate()
        {
            Active = false;
        }

        public void UpdatePromotion(string description, int minimumQuantity, decimal discount)
        {
            Description = description;
            MinimumQuantity = minimumQuantity;
            Discount = discount;
        }

    }
}
