using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Queries.Results
{
    public class CartQueryResult
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<CartItemQueryResult> Items { get; set; }

        public void SetTotal()
        {
            Total = Items.Sum(x => x.Total);
        }
    }
}
