using Klir.TechChallenge.Web.Domain.Product.Entities;
using Klir.TechChallenge.Web.Domain.Product.Queries.Results;
using Klir.TechChallenge.Web.Domain.Product.Repositories;
using Klir.TechChallenge.Web.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Web.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public IEnumerable<ProductQueryResult> GetProduct()
        {
            return _context
                .Products
                .AsNoTracking()
                .Include(x => x.Promotion)
                .Where(x => !x.Deleted)
                .Select(x => new ProductQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Promotion = x.Promotion == null ? null : new ProductPromotionQueryResult
                    {
                        Id = x.Promotion.Id,
                        Description = x.Promotion.Description,
                        Discount = x.Promotion.Discount,
                        MinimumQuantity = x.Promotion.MinimumQuantity,
                    }
                })
                .ToList();
        }

        public ProductQueryResult GetByProduct(Guid id)
        {
            var product = _context
                .Products
                .AsNoTracking()
                .Include(x => x.Promotion)
                .Where(x => !x.Deleted)
                .Select(x => new ProductQueryResult
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Promotion = x.Promotion == null ? null : new ProductPromotionQueryResult
                    {
                        Id = x.Promotion.Id,
                        Description = x.Promotion.Description,
                        Discount = x.Promotion.Discount,
                        MinimumQuantity = x.Promotion.MinimumQuantity,
                    }
                })
                .FirstOrDefault(x => x.Id == id);

            return product;
        }

        public Product GetById(Guid id)
        {
            return _context
                .Products
                .Include(x => x.Promotion)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
