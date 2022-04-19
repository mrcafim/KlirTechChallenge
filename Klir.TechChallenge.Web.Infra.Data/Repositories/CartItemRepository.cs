using Klir.TechChallenge.Web.Domain.Cart.Entities;
using Klir.TechChallenge.Web.Domain.Cart.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Infra.Data.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DataContext _context;

        public CartItemRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(CartItem cart)
        {
            _context.CartItems.Add(cart);
        }
    }
}
