using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Product.Queries.Results
{
    public class ProductQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductPromotionQueryResult Promotion { get; set; }
    }
}
