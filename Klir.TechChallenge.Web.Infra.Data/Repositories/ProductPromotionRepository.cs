using Klir.TechChallenge.Web.Domain.Product.Entities;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klir.TechChallenge.Web.Infra.Data.Repositories
{
    public class ProductPromotionRepository : IProductPromotionRepository
    {
        private readonly DataContext _context;

        public ProductPromotionRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(ProductPromotion product)
        {
            _context.ProductPromotions.Add(product);
        }
        public void Update(ProductPromotion product)
        {
            _context.ProductPromotions.Update(product);
        }

        public ProductPromotion GetById(Guid id)
        {
            return _context
                .ProductPromotions
                .FirstOrDefault(x => x.Id == id);
        }

        public ProductPromotion GetByProductId(Guid productId)
        {
            return _context
                .ProductPromotions
                .FirstOrDefault(x => x.ProductId == productId);
        }
    }
}
