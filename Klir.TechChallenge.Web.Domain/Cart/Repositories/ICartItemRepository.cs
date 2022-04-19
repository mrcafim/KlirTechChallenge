using System;

namespace Klir.TechChallenge.Web.Domain.Cart.Repositories
{
    public interface ICartItemRepository : IDisposable
    {
        void Add(Entities.CartItem cart);
    }
}
