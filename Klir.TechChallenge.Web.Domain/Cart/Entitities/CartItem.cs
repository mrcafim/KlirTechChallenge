using Klir.TechChallenge.Web.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Entitities
{
    public class CartItem : Entity
    {
        public CartItem() { }

        public CartItem(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public Guid ProductId { get; protected set; }
        public virtual Product.Entities.Product Product { get; protected set; }
        public int Quantity { get; private set; }

        public bool IsValid()
        {
            return ProductId != null && Quantity > 0;
        }

    }
}
