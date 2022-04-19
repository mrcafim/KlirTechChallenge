using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Domain.Cart.Repositories
{
    public interface ICartItemRepository : IDisposable
    {
        void Add(Entities.CartItem cart);
    }
}
