using Klir.TechChallenge.Web.Domain.Cart.Entities;
using Klir.TechChallenge.Web.Domain.Cart.Queries.Results;
using Klir.TechChallenge.Web.Domain.Cart.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klir.TechChallenge.Web.Infra.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _context;

        public CartRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public void Update(Cart cart)
        {
            _context.Carts.Update(cart);
        }

        public Cart GetById(Guid id)
        {
            return _context
                .Carts
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);
        }

        public CartQueryResult GetByCart(Guid id)
        {
            var cart = _context
                .Carts
                .AsNoTracking()
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Promotion)
                .Select(x => new CartQueryResult
                {
                    Id = x.Id,
                    Items = x.Items
                        .Select(c => new CartItemQueryResult
                        {
                            Id = c.Id,
                            ProductId = c.ProductId,
                            Name = c.Product.Name,
                            Quantity = c.Quantity,
                            Price = c.Product.Price,
                            PromotionName = c.Product.Promotion != null ? c.Product.Promotion.Description : null,
                            PromotionDiscount = c.Product.Promotion != null ? c.Product.Promotion.Discount : 0,
                            PromotionMinimumQuantity = c.Product.Promotion != null ? c.Product.Promotion.MinimumQuantity : 0,
                        })

                })
                .FirstOrDefault(x => x.Id == id);

            cart.SetTotal();

            return cart;
            ;
        }
    }
}
