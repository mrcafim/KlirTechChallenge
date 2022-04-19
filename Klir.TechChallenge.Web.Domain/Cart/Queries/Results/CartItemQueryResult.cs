using System;

namespace Klir.TechChallenge.Web.Domain.Cart.Queries.Results
{
    public class CartItemQueryResult
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string PromotionName { get; set; }
        public int PromotionMinimumQuantity { get; set; }
        public decimal PromotionDiscount { get; set; }

        public void CalculateDiscount(decimal discount, int minimumQuantity)
        {
            if (discount <= 0)
            {
                Total = Price * Quantity;
            }
            else
            {
                for (int i = 0; i < this.Quantity; i = i + minimumQuantity)
                {
                    Discount += discount;
                }
                Total = (Price * Quantity) - Discount;
            }
        }
    }
}
