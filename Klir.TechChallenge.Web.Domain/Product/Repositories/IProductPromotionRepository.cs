using Klir.TechChallenge.Web.Domain.Product.Entities;
using System;

namespace Klir.TechChallenge.Web.Domain.Product.Repositories
{
    public interface IProductPromotionRepository : IDisposable
    {
        void Add(ProductPromotion product);
        void Update(ProductPromotion product);
        ProductPromotion GetById(Guid id);
        ProductPromotion GetByProductId(Guid productId);
    }
}
