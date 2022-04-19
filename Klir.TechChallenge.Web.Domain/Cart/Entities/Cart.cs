using Klir.TechChallenge.Web.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Entities
{
    public class Cart : Entity
    {
        public Cart()
        {
            Active = true;
            CreatedAt = DateTime.Now;
            Items = new List<CartItem>();
        }

        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public virtual ICollection<CartItem> Items { get; protected set; }

        public bool AddItem(Guid productId, int quantity)
        {
            var cart = new CartItem(productId, quantity);

            var valid = cart.IsValid();

            if (valid)
                Items.Add(cart);

            return valid;
        }

        public void ClearCart()
        {
            Items.Clear();
        }

    }
}
