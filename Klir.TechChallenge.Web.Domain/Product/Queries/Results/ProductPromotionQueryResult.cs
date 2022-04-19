using System;

namespace Klir.TechChallenge.Web.Domain.Product.Queries.Results
{
    public class ProductPromotionQueryResult
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal MinimumQuantity { get; set; }
        public decimal Discount { get; set; }

    }
}
