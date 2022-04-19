using Klir.TechChallenge.Web.Domain.Product.Queries.Results;
using System;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Domain.Product.Repositories
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductQueryResult> GetProduct();
        ProductQueryResult GetByProduct(Guid id);
        void Add(Entities.Product product);
        void Update(Entities.Product product);
        void Delete(Entities.Product product);
        Entities.Product GetById(Guid id);
    }
}
